import axiosClient from './axiosClient'

const User = {

    Get_All_User: () => {
        const url = '/api/User'
        return axiosClient.get(url)
    },

    Get_User: (id) => {
        const url = `/api/User/${id}`
        return axiosClient.get(url)
    },

    Get_Detail_User: (query) => {
        const url = `/api/User/detail${query}`
        return axiosClient.get(url)
    },
    Change_Profile: (query) => {
        const url = `/api/User/${query}`
        return axiosClient.put(url)
    },
    Change_Password: (query) => {
        const url = `/api/User/changepassword${query}`
        return axiosClient.put(url)
    },
    Forget: (query) => {
        const url = `/api/User/forget${query}`
        return axiosClient.put(url)
    },
    Post_User: (data) => {
        const url = '/api/User'
        return axiosClient.post(url, data)
    },
    Post_OTP: (query) => {
        const url = `/api/User/otp${query}`
        return axiosClient.get(url)
    }

}

export default User