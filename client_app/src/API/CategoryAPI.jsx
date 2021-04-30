import axiosClient from './axiosClient'

const CategoryAPI = {

    get_all_category: () => {
        const url = '/api/Category'
        return axiosClient.get(url)
    }

}

export default CategoryAPI