import axiosClient from './axiosClient'

const OrderAPI = {

    // post_paypal: (data) => {
    //     const url = `/api/Payment/paypal`
    //     return axiosClient.post(url, data)
    // },

    post_history: (data) => {
        const url = `/api/History`
        return axiosClient.post(url, data)
    },

    post_delivery: (data) => {
        const url = `/api/Delivery`
        return axiosClient.post(url, data)
    },

    post_sendmail: (query) => {
        const url = `/api/History/sendmail${query}`
        return axiosClient.post(url)
    }

}

export default OrderAPI