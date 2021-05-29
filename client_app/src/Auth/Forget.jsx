import React, { useState } from 'react';
import { Link, Redirect } from 'react-router-dom';
import queryString from 'query-string'
import User from '../API/User';
import isEmpty from 'validator/lib/isEmpty'
import isEmail from 'validator/lib/isEmail'

let otp;

function Forget(props) {
    const [validationMsg, setValidationMsg] = useState('');
    const [email, setEmail] = useState('');
    const [OTP, setOTP] = useState('');
    const [change, setChange] = useState(true)
    const [new_password, set_new_password] = useState('')
    const [compare_password, set_compare_password] = useState('')
    const [redirect, set_redirect] = useState(false)

    const validateAll = () => {
        let msg = {}
        if (isEmpty(email)) {
            msg.email = "Email không được để trống"
        } else if (!isEmail(email)) {
            msg.email = "Email sai định dạng"
        }
        setValidationMsg(msg)
        if (Object.keys(msg).length > 0) return false;
        return true;
    }
    const handleOTP = async () => {
        const isValid = validateAll();
        if (!isValid) return

        otp = Math.floor(Math.random() * 1000000);

        const query = '?' + queryString.stringify({ email: email, otp: otp })

        const response = await User.Post_OTP(query)

        setValidationMsg({ api: response })

    }

    const handleChange = () => {
        const isValid = validateAll();
        if (!isValid) return
        console.log(otp)
        console.log(OTP)
        if (OTP == otp) {
            setChange(false)
        } else {
            setValidationMsg({ otp: "Sai mã OTP" })
        }
    }

    const validateAllPassword = () => {
        let msg = {}
        if (isEmpty(new_password)) {
            msg.new_password = "New password không được để trống"
        }
        if (compare_password !== new_password) {
            msg.compare_password = "Xác nhận password không đúng"
        }
        setValidationMsg(msg)
        if (Object.keys(msg).length > 0) return false;
        return true;
    }


    const changePassword = async () => {
        const isValid = validateAllPassword();
        if (!isValid) return
        const query = '?' + queryString.stringify({ newPassword: new_password, email: email })

        const response = await User.Forget(query)
        set_redirect(true)

    }

    return (
        <div>
            <div className="breadcrumb-area">
                <div className="container">
                    <div className="breadcrumb-content">
                        <ul>
                            <li><Link to="/">Home</Link></li>
                            <li className="active">Login</li>
                        </ul>
                    </div>
                </div>
            </div>
            <div className="page-section mb-60">
                <div className="container">
                    <div className="row">
                        <div className="col-sm-12 col-md-12 col-xs-12 col-lg-6 mb-30 mr_signin">

                            {
                                change === true ?
                                    (
                                        <div className="login-form">
                                            <h4 className="login-title">Forget Password</h4>
                                            <p className="form-text text-danger">{validationMsg.api}</p>
                                            <div className="row">
                                                <div className="col-md-12 col-12 mb-20">
                                                    <label>Email</label>
                                                    <p className="text-danger">{validationMsg.email}</p>
                                                    <div className="d-flex">
                                                        <input className="mb-0" type="text" placeholder="Email" value={email} onChange={(e) => setEmail(e.target.value)} />
                                                        <button type="button" onClick={handleOTP} className="register-button" style={{ cursor: 'pointer', padding: '0px', margin: '0px', height: '45px' }}>Gửi mã OTP</button>
                                                    </div>
                                                </div>

                                                <div className="col-md-12 col-12 mb-20">
                                                    <label>OTP</label>
                                                    <p className="text-danger">{validationMsg.otp}</p>
                                                    <input className="mb-0" type="text" placeholder="OTP" value={OTP} onChange={(e) => setOTP(e.target.value)} />
                                                </div>

                                                <div className="col-md-8">
                                                    <div className="check-box d-inline-block ml-0 ml-md-2 mt-10">
                                                        <Link to="/signup">Do You Have Account?</Link>
                                                    </div>
                                                </div>



                                                <div className="col-md-12">
                                                    <button type="button" onClick={handleChange} className="register-button mt-0" style={{ cursor: 'pointer' }}>Change</button>
                                                </div>
                                            </div>
                                        </div>
                                    ) :
                                    (
                                        <div className="login-form">
                                            <h4 className="login-title">Change Password</h4>
                                            <p className="form-text text-danger">{validationMsg.api}</p>
                                            <div className="row">
                                                <div className="col-md-12 col-12 mb-20">
                                                    <label for="passwordNew">New Password</label>
                                                    <input className="txt_input_edit" type="password" id="passwordNew" value={new_password}
                                                        onChange={(e) => set_new_password(e.target.value)} />
                                                    <p className="text-danger">{validationMsg.set_new_password}</p>
                                                </div>

                                                <div className="col-md-12 col-12 mb-20">
                                                    <label for="password">ConfirmPassword</label>
                                                    <input className="txt_input_edit" type="password" id="password" value={compare_password}
                                                        onChange={(e) => set_compare_password(e.target.value)} />
                                                    <p className="text-danger">{validationMsg.compare_password}</p>
                                                </div>


                                                <div className="col-md-12">
                                                    {
                                                        redirect && <Redirect to="/signin" />
                                                    }
                                                    <button type="button" onClick={changePassword} className="register-button mt-0" style={{ cursor: 'pointer' }}>Submit</button>
                                                </div>
                                            </div>
                                        </div>
                                    )
                            }

                        </div>
                    </div>
                </div>
            </div>
        </div>
    );
}

export default Forget;