import axiosClient from './axiosClient'

const Product = {

    Get_All_Product: () => {
        const url = '/api/Product'
        return axiosClient.get(url)
    },

    Get_Category_Product: (query) => {
        const url = `/api/Product${query}`
        return axiosClient.get(url)
    },

    Get_Detail_Product: (id) => {
        const url = `/api/Product/${id}`
        return axiosClient.get(url)
    }

}

export default Product