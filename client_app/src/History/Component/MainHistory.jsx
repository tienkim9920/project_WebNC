import React, { useEffect, useState } from 'react';
import PropTypes from 'prop-types';
import { Link } from 'react-router-dom';
import HistoryAPI from '../../API/HistoryAPI';
import queryString from 'query-string'

MainHistory.propTypes = {

};

function MainHistory(props) {

    const [history, set_history] = useState([])

    useEffect(() => {

        const fetchData = async () => {

            const params = {
                id_user: sessionStorage.getItem('id_user')
            }

            const query = '?' + queryString.stringify(params)

            const response = await HistoryAPI.get_history(query)

            console.log(response)

            set_history(response)

        }

        fetchData()

    }, [])

    return (
        <div>
            <div className="breadcrumb-area">
                <div className="container">
                    <div className="breadcrumb-content">
                        <ul>
                            <li><Link to="/">Home</Link></li>
                            <li className="active">History</li>
                        </ul>
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
                                                <th className="li-product-remove">ID Invoice</th>
                                                <th className="li-product-price">Address</th>
                                                <th className="li-product-quantity">Total</th>
                                                <th className="li-product-subtotal">Payment</th>
                                                <th className="li-product-subtotal">Status</th>
                                            </tr>
                                        </thead>
                                        <tbody>
                                            {
                                                history && history.map(value => (
                                                    <tr key={value.id_history}>
                                                        <td className="li-product-price"><span className="amount"><Link to={`/history/${value.id_history}`}>View</Link></span></td>
                                                        <td className="li-product-price"><span className="amount">{value.address}</span></td>
                                                        <td className="li-product-price"><span className="amount">{value.total}</span></td>
                                                        <td className="li-product-price"><span className="amount" style={value.pay ? { color: 'green'} : { color: 'red'}}>{value.status ? 'Paid' : 'Unpaid'}</span></td>
                                                        <td className="li-product-price">
                                                            <span className="amount" style={{ cursor: 'pointer' }}>
                                                            {
                                                            value.status === '1' ? 'X' : 
                                                            (value.status === '2' ? 'Confirmed' : 
                                                            (value.status === '3' ? 'Shipping' : 
                                                            (value.status === '4' ? 'Finished' : 'Undifine'))) }
                                                            </span>
                                                        </td>
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

export default MainHistory;