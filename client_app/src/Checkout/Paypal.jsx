import React, { useEffect, useRef, useState } from 'react';
import PropTypes from 'prop-types';
import { Redirect } from 'react-router-dom'
import OrderAPI from '../API/OrderAPI';
import { changeCount } from '../Redux/Action/ActionCount';
import { useDispatch, useSelector } from 'react-redux';
import HistoryAPI from '../API/HistoryAPI';
import Cart from '../API/CartAPI';
import queryString from 'query-string'

Paypal.propTypes = {
    information: PropTypes.object,
    total: PropTypes.number,
    Change_Load_Order: PropTypes.func,
    from: PropTypes.string,
    distance: PropTypes.string,
    duration: PropTypes.string,
    price: PropTypes.string,
    carts: PropTypes.array,
    email: PropTypes.string
};

Paypal.defaultProps = {
    information: {},
    total: 0,
    Change_Load_Order: null,
    from: '',
    distance: '',
    duration: '',
    price: '',
    carts: [],
    email: ''
}

function Paypal(props) {

    let { information, total, Change_Load_Order, from, distance, duration, price, carts, email } = props

    console.log(email)

    const paypal = useRef()

    const [redirect, set_redirect] = useState(false)

    const count_change = useSelector(state => state.Count.isLoad)

    const dispatch = useDispatch()

    useEffect(() => {
        window.paypal.Buttons({
            createOrder: (data, actions, err) => {
                return actions.order.create({
                    intent: "CAPTURE",
                    purchase_units: [
                        {
                            description: "Hóa Đơn Đặt Hàng",
                            amount: {
                                currency_code: "USD",
                                value: total,
                            },
                        },
                    ],
                })
            },
            onApprove: async (data, actions) => {
                const order = await actions.order.capture();
                console.log(order)

                Change_Load_Order(true)

                const id_find = Math.random().toString()
                const id_history = Math.random().toString()
                const id_delivery = Math.random().toString()

                let body_history = {
                    //History
                    id_history: id_history,
                    id_user: sessionStorage.getItem('id_user'),
                    id_find: id_find,
                    fullname: information.fullname,
                    phone: information.phone,
                    address: information.address,
                    email: email,
                    total: total.toString(),
                    status: true,
                    delivery: 0,
                    id_payment: '60635313a1ba573dc01656b5', //  Paypal
                }

                const body_delivery = {
                    //Delivery
                    id_delivery: id_delivery,
                    id_history: id_history,
                    address_from: from,
                    address_to: information.address,
                    distance: distance,
                    duration: duration,
                    price: price
                }

                console.log(body_history)

                // Gọi API post history
                const response = await OrderAPI.post_history(body_history)

                // Gọi API post delivery
                const response_delivery = await OrderAPI.post_delivery(body_delivery)

                // Gọi API Sendmail và post Detail_History và xóa data trong Cart
                const params = {
                    id_find: id_find
                }

                const query = '?' + queryString.stringify(params)

                const response_sendmail = await OrderAPI.post_sendmail(query)

                console.log(response)
                console.log(response_delivery)
                console.log(response_sendmail)

                // Phần này là xử lý POST vào detail_history
                for (let i = 0; i < carts.length; i++) {

                    const data = {
                        id_detail_history: "CT" + Math.random().toString(),
                        id_history: id_history,
                        name_product: carts[i].name_product,
                        price_product: carts[i].price_product,
                        count: parseInt(carts[i].count),
                        image: carts[i].image
                    }

                    console.log(data)

                    // Gọi API post data thêm data vào Detail_History
                    const response_detail_history = await HistoryAPI.post_detail_history(data)

                    const resonse_delete_carts = await Cart.Delete_Cart(carts[i].id_cart)

                }

                set_redirect(true)
                
                // // Hàm này dùng để load lại phần header bằng Redux
                const action_count_change = changeCount(count_change)
                dispatch(action_count_change)

                set_redirect(true)

            },
            onError: (err) => {
                console.log("Vui Lòng Kiểm Tra Lại Thông Tin")
            }
        }).render(paypal.current)

    }, [])

    return (
        <div>
            {
                redirect && <Redirect to="/success" />
            }
            <div ref={paypal}>

            </div>
        </div>

    );
}

export default Paypal;