import React, { useEffect, useState } from 'react';
import PropTypes from 'prop-types';
import { Link, useParams } from 'react-router-dom';
import HistoryAPI from '../../API/HistoryAPI';
import './History.css'
import OrderAPI from '../../API/OrderAPI';

DetailHistory.propTypes = {

};

function DetailHistory(props) {

    const { id } = useParams()

    const [history, set_history] = useState({})

    const [detail_history, set_detail_history] = useState([])

    const [note, set_note] = useState({})

    useEffect(() => {

        const fetchData = async () => {

            const response = await HistoryAPI.get_detail_history(id)
            set_history(response)

            const response_detail = await HistoryAPI.get_history_view(id)
            set_detail_history(response_detail)

            const res_note = await OrderAPI.get_note(response.id_note)
            set_note(res_note)
            
        }

        fetchData()

    }, [])

    return (
        <div>
            <div className="container" style={{ paddingTop: '3rem' }}>
                <h1>Thông Tin Chi Tiết Đơn Hàng</h1>
                <ul>
                    <li style={{ fontSize: '1.1rem' }}>ID Invoice: <span>{history.id_history}</span></li>
                    <li style={{ fontSize: '1.1rem' }}>Fullname: <span>{note.fullname}</span></li>
                    <li style={{ fontSize: '1.1rem' }}>Phone: <span>{note.phone}</span></li>
                    <li style={{ fontSize: '1.1rem' }}>Address: <span>{history.address}</span></li>
                    <li style={{ fontSize: '1.1rem' }}>FeeShip: <span>{history.feeship}$</span></li>
                    <li style={{ fontSize: '1.1rem' }}>Total: <span>{history.total}$</span></li>
                </ul>
                <div className="group_box_status" style={{ marginTop: '3rem'}}>
                    <div className="d-flex justify-content-center">
                        <div className="group_status_delivery d-flex justify-content-around">
                            <div className="detail_status_delivery">
                                <div className="w-100 d-flex justify-content-center">
                                    <div className={history.status > 0 && 'bg_status_delivery_active'}></div>
                                </div> 
                                <a className="a_status_delivery">Processing</a>
                            </div>

                            <div className="detail_status_delivery">
                                <div className="w-100 d-flex justify-content-center">
                                    <div className={history.status > 1 ? 'bg_status_delivery_active' : 'bg_status_delivery'}></div>
                                </div> 
                                <a className="a_status_delivery">Confirmed</a>
                            </div> 

                            <div className="detail_status_delivery">
                                <div className="w-100 d-flex justify-content-center">
                                    <div className={history.status > 2 ? 'bg_status_delivery_active' : 'bg_status_delivery'}></div>
                                </div> 
                                <a className="a_status_delivery">Shipping</a>
                            </div> 

                            <div className="detail_status_delivery">
                                <div className="w-100 d-flex justify-content-center">
                                    <div className={history.status > 3 ? 'bg_status_delivery_active' : 'bg_status_delivery'}></div>
                                </div> 
                                <a className="a_status_delivery">Finished</a>
                            </div>
                        </div>
                    </div>    
                    <div className="test_status d-flex justify-content-center">   
                        <div className="hr_status_delivery"></div>   
                    </div>
                </div>
            </div>

            <div className="Shopping-cart-area pt-60 pb-60">
                <div className="container">
                    <div className="row">
                        <div className="col-12">
                            <form action="#">
                                <div className="table-content table-responsive">
                                    <table className="table">
                                        <thead>
                                            <tr>
                                                <th className="li-product-remove">Image</th>
                                                <th className="li-product-thumbnail">Name Product</th>
                                                <th className="cart-product-name">Price</th>
                                                <th className="li-product-price">Count</th>
                                                <th className="li-product-price">Total</th>
                                            </tr>
                                        </thead>
                                        <tbody>
                                            {
                                                detail_history && detail_history.map(value => (
                                                    <tr key={value.id_detail_history}>
                                                        <td className="li-product-thumbnail"><img src={value.image} style={{ width: '5rem'}} alt="Li's Product Image" /></td>
                                                        <td className="li-product-name"><a href="#">{value.name_product}</a></td>
                                                        <td className="li-product-price"><span className="amount">${value.price_product}</span></td>
                                                        <td className="li-product-price"><span className="amount">{value.count}</span></td>
                                                        <td className="li-product-price"><span className="amount">${parseInt(value.count) * parseInt(value.price_product)}</span></td>
                                                    </tr>
                                                ))
                                            }
                                            
                                        </tbody>
                                    </table>
                                </div>
                            </form>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    );
}

export default DetailHistory;