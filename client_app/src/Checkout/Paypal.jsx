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

                const id_history = Math.random().toString()
                const id_note = Math.random().toString()

                const body_order = {
                    //Order
                    id_history: id_history,
                    address: information.address.toString(),
                    total: total.toString(),
                    status: "1",
                    pay: true,
                    feeship: parseInt(price),
                    id_user: sessionStorage.getItem('id_user'),
                    id_payment: '60635313a1ba573dc01656b5', // Trực Tuyến
                    id_note: id_note.toString()
                }

                const body_note = {
                    //Note
                    id_note: id_note,
                    fullname: information.fullname.toString(),
                    phone: information.phone.toString()
                }


                // Gọi API post delivery
                const response_note = await OrderAPI.post_note(body_note)

                // Gọi API post history
                const response = await OrderAPI.post_history(body_order)


                // data carts
                const data_carts = JSON.parse(localStorage.getItem('carts'))

                // Phần này là xử lý POST vào detail_history
                for (let i = 0; i < data_carts.length; i++) {

                    const data = {
                        id_detail_history: "CT" + Math.random().toString(),
                        id_history: id_history,
                        name_product: data_carts[i].name_product,
                        price_product: data_carts[i].price_product,
                        count: parseInt(data_carts[i].count),
                        image: data_carts[i].image,
                        id_product: data_carts[i].id_product
                    }

                    console.log(data)

                    // Gọi API post data thêm data vào Detail_History
                    await HistoryAPI.post_detail_history(data)

                }

                localStorage.setItem('carts', JSON.stringify([]))

                set_redirect(true)

                // Hàm này dùng để load lại phần header bằng Redux
                const action_count_change = changeCount(count_change)
                dispatch(action_count_change)

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