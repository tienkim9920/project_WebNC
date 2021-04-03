import axiosClient from './axiosClient'

const CartAPI = {

    Get_Cart: (query) => {
        const url = `/api/Cart${query}`
        return axiosClient.get(url)
    },

    Post_Cart: (data) => {
        const url = '/api/Cart'
        return axiosClient.post(url, data)
    },

    Delete_Cart: (id) => {
        const url = `/api/Cart/${id}`
        return axiosClient.delete(url)
    },

    Put_Cart: (query) => {
        const url = `/api/Cart${query}`
        return axiosClient.put(url)
    }

}

export default CartAPI