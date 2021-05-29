import React, { useEffect, useState } from 'react';
import PropTypes from 'prop-types';
import './Profile.css'
import avt from './avt.jpg'
import User from '../API/User';
import queryString from 'query-string'
import isEmpty from 'validator/lib/isEmpty'

Profile.propTypes = {

};

function Profile(props) {
    const [validationMsg, setValidationMsg] = useState('');
    const [name, set_name] = useState('')
    const [username, set_username] = useState('')
    const [email, set_email] = useState('')
    const [password, set_password] = useState('')
    const [new_password, set_new_password] = useState('')
    const [compare_password, set_compare_password] = useState('')
    const [message, setMessage] = useState('')
    const [message1, setMessage1] = useState('')

    // Hàm này dùng để render html cho từng loại edit profile hoặc change password
    // Tùy theo người dùng chọn
    const [edit_status, set_edit_status] = useState('edit_profile')

    const handler_Status = (value) => {

        set_edit_status(value)

    }

    const [user, set_user] = useState({})

    useEffect(() => {

        const fetchData = async () => {

            const response = await User.Get_User(sessionStorage.getItem('id_user'))

            set_user(response)

            set_name(response.fullname)

            set_username(response.username)

            set_email(response.email)

        }

        fetchData()

    }, [])



    const validateAll = () => {
        let msg = {}
        if (isEmpty(name)) {
            msg.name = "Name không được để trống"
        }
        setValidationMsg(msg)
        if (Object.keys(msg).length > 0) return false;
        return true;
    }

    const handleSubmit = async () => {
        const isValid = validateAll();
        if (!isValid) return
        const query = '?' + queryString.stringify({ fullname: name, id_user: sessionStorage.getItem('id_user') })

        const response = await User.Change_Profile(query)

        setMessage(response)
    }

    const validateAllPassword = () => {
        let msg = {}
        if (isEmpty(password)) {
            msg.password = "Old password không được để trống"
        }
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
        const query = '?' + queryString.stringify({ password: password, newPassword: new_password, id_user: sessionStorage.getItem('id_user') })

        const response = await User.Change_Password(query)

        setMessage1(response)
    }


    return (
        <div className="container mt-5 pt-4" style={{ paddingBottom: '4rem' }}>
            <div className="group_profile">
                <div className="group_setting mt-3">
                    <div className="setting_left">
                        <div className={edit_status === 'edit_profile' ? 'setting_item setting_item_active' : 'setting_item'}
                            onClick={() => handler_Status('edit_profile')}>

                            <a className={edit_status === 'edit_profile' ? 'a_setting_active' : ''}
                                style={{ fontSize: '1.1rem' }}>Edit Profile</a>

                        </div>

                        <div className={edit_status === 'change_password' ? 'setting_item setting_item_active' : 'setting_item'}
                            onClick={() => handler_Status('change_password')}>

                            <a className={edit_status === 'change_password' ? 'a_setting_active' : ''}
                                style={{ fontSize: '1.1rem' }}>Change Password</a>

                        </div>
                    </div>
                    <div className="setting_right">
                        {
                            edit_status === 'edit_profile' ? (
                                <div className="setting_edit_profile">
                                    <p className="text-success text-center">{message ? message : ""}</p>
                                    <div className="txt_setting_edit pt-3 pb-2">
                                        <div className="d-flex justify-content-center align-items-center">
                                            <span style={{ fontWeight: '600' }}>Name</span>
                                        </div>
                                        <div>
                                            <input className="txt_input_edit" type="text" value={name}
                                                onChange={(e) => set_name(e.target.value)} required />
                                            <p className="text-danger">{validationMsg.name}</p>
                                        </div>

                                    </div>
                                    <div className="txt_setting_edit pt-3 pb-2">
                                        <div className="d-flex justify-content-center align-items-center">
                                            <span style={{ fontWeight: '600' }}>Username</span>
                                        </div>
                                        <div>
                                            <input className="txt_input_edit" type="text" value={username} disabled={true} />
                                        </div>
                                    </div>
                                    <div className="txt_setting_edit pt-3 pb-2">
                                        <div className="d-flex justify-content-center align-items-center">
                                            <span style={{ fontWeight: '600' }}>Email</span>
                                        </div>
                                        <div>
                                            <input className="txt_input_edit" type="text" disabled={true} value={email} />
                                        </div>
                                    </div>
                                    <div className="d-flex justify-content-center pt-3 pb-4">
                                        <button onClick={handleSubmit} className="btn btn-secondary">Submit</button>
                                    </div>
                                </div>
                            ) : (
                                <div className="setting_change_password">
                                    {
                                        message1 === "Update thành công!" ?
                                            (
                                                <p className="text-success text-center">{message1}</p>
                                            ) :
                                            (
                                                <p className="text-danger text-center">{message1}</p>
                                            )
                                    }

                                    <div className="txt_setting_edit pt-3 pb-2">
                                        <div className="d-flex justify-content-center align-items-center">
                                            <span style={{ fontWeight: '600' }}>Old Password</span>
                                        </div>
                                        <div>
                                            <input className="txt_input_edit" type="password" value={password}
                                                onChange={(e) => set_password(e.target.value)} />
                                            <p className="text-danger">{validationMsg.password}</p>
                                        </div>
                                    </div>
                                    <div className="txt_setting_edit pt-3 pb-2">
                                        <div className="d-flex justify-content-center align-items-center">
                                            <span style={{ fontWeight: '600' }} >New Password</span>
                                        </div>
                                        <div>
                                            <input className="txt_input_edit" type="password" value={new_password}
                                                onChange={(e) => set_new_password(e.target.value)} />
                                            <p className="text-danger">{validationMsg.new_password}</p>
                                        </div>
                                    </div>
                                    <div className="txt_setting_edit pt-3 pb-2">
                                        <div className="d-flex justify-content-center align-items-center">
                                            <span style={{ fontWeight: '600' }}>Confirm New Password</span>
                                        </div>
                                        <div>
                                            <input className="txt_input_edit" type="password" value={compare_password}
                                                onChange={(e) => set_compare_password(e.target.value)} />
                                            <p className="text-danger">{validationMsg.compare_password}</p>
                                        </div>
                                    </div>
                                    <div className="d-flex justify-content-center pt-3 pb-4 align-items-center">
                                        <button onClick={changePassword} className="btn btn-secondary">Change Password</button>
                                    </div>
                                </div>
                            )
                        }
                    </div>
                </div>
            </div>
        </div>
    );
}

export default Profile;