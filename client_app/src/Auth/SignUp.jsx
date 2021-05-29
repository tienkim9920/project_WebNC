import React, { useEffect, useState } from 'react';
import PropTypes from 'prop-types';
import { Link, useHistory } from 'react-router-dom';
import User from '../API/User';
import { useForm } from 'react-hook-form'

SignUp.propTypes = {

};

const defaultValues = {
    name: '',
    email: '',
    username: '',
    password: '',
    confirmPassword: ''
};

function SignUp(props) {

    const { register, handleSubmit, reset, formState: { errors } } = useForm({ defaultValues });

    const [show_success, set_show_success] = useState(false)

    const [errorCheckPass, setCheckPass] = useState(false)

    const [username_exist, set_username_exist] = useState(false)

    const onSubmit = (data) => {

        if (data.password !== data.confirmPassword) {
            setCheckPass(true)
            return
        }

        setCheckPass(false)

        const fetchData = async () => {

            const body = {
                id_user: Math.random().toString().replace(".", ""),
                username: data.username.toString(),
                password: data.confirmPassword.toString(),
                fullname: data.name.toString(),
                id_permission: '04859514654',
                email: data.email.toString()
            }

            console.log(body)

            const response = await User.Post_User(body)

            if (response === "Username hoặc Email đã tồn tại") {
                set_username_exist(true)
            } else {
                set_username_exist(false)
                set_show_success(true)
                reset(defaultValues)
            }


        }

        fetchData()


        setTimeout(() => {
            set_show_success(false)
        }, 1500)

    }


    return (
        <div>

            {
                show_success &&
                <div className="modal_success">
                    <div className="group_model_success pt-3">
                        <div className="text-center p-2">
                            <i className="fa fa-bell fix_icon_bell" style={{ fontSize: '40px', color: '#fff' }}></i>
                        </div>
                        <h4 className="text-center p-3" style={{ color: '#fff' }}>Bạn Đã Đăng Ký Thành Công!</h4>
                    </div>
                </div>
            }

            <div className="breadcrumb-area">
                <div className="container">
                    <div className="breadcrumb-content">
                        <ul>
                            <li><Link to="/">Home</Link></li>
                            <li className="active">Register</li>
                        </ul>
                    </div>
                </div>
            </div>
            <div className="page-section mb-60">
                <div className="container">
                    <div className="row">
                        <div className="col-sm-12 col-md-12 col-lg-6 col-xs-12 mr_signin">
                            <form onSubmit={handleSubmit(onSubmit)}>
                                <div className="login-form">
                                    <h4 className="login-title">Register</h4>
                                    {
                                        username_exist && <span style={{ color: 'red' }}>Username hoặc Email đã tồn tại</span>
                                    }
                                    <div className="row">
                                        <div className="col-md-12 mb-20">
                                            <label>Full Name *</label>
                                            <input className="mb-0" type="text" placeholder="First Name"
                                                name="name"
                                                ref={register({ required: true })}
                                            />
                                            {
                                                errors.name && errors.name.type === "required" && <span style={{ color: 'red' }}>* Fullname is required</span>
                                            }
                                        </div>
                                        <div className="col-md-12 mb-20">
                                            <label>Email *</label>
                                            <input className="mb-0" type="text" placeholder="Email"
                                                name="email" ref={register({ required: true })} />
                                            {
                                                errors.email && errors.email.type === "required" && <span style={{ color: 'red' }}>* Email is required</span>
                                            }
                                        </div>
                                        <div className="col-md-12 mb-20">
                                            <label>Username *</label>
                                            <input className="mb-0" type="text" placeholder="Username" name="username" ref={register({ required: true })} />
                                            {
                                                errors.username && errors.username.type === "required" && <span style={{ color: 'red' }}>* Username is required</span>
                                            }
                                        </div>
                                        <div className="col-md-6 mb-20">
                                            <label>Password *</label>
                                            <input className="mb-0" type="password" placeholder="Password" name="password" ref={register({ required: true })} />
                                            {
                                                errors.password && errors.password.type === "required" && <span style={{ color: 'red' }}>* Password is required</span>
                                            }
                                        </div>
                                        <div className="col-md-6 mb-20">
                                            <label>Confirm Password *</label>
                                            <input className="mb-0" type="password" placeholder="Confirm Password" name="confirmPassword" ref={register({ required: true })} />
                                            {
                                                errors.confirmPassword && errors.confirmPassword.type === "required" && <span style={{ color: 'red' }}>*Confirm Password is required</span>
                                            }
                                            {
                                                errorCheckPass && <span style={{ color: 'red' }}>* Checking Again Confirm Password!</span>
                                            }
                                        </div>
                                        <div className="col-md-12 mb-20">
                                            <div className="d-flex justify-content-end">
                                                <Link to="/signin">Do You Want To Login?</Link>
                                            </div>
                                        </div>
                                        <div className="col-12">
                                            <button className="register-button mt-0" style={{ cursor: 'pointer' }} type="submit" >Register</button>
                                        </div>
                                    </div>
                                </div>
                            </form>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    );
}

export default SignUp;