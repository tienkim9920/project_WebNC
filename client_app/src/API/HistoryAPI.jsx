import axiosClient from './axiosClient'

const HistoryAPI = {

    get_history: (query) => {
        const url = `/api/History${query}`
        return axiosClient.get(url)
    },

    get_history_view: (id) => {
        const url = `/api/DetailHistory/${id}`
        return axiosClient.get(url)
    },

    get_detail_history: (id) => {
        const url = `/api/History/${id}`
        return axiosClient.get(url)
    },

    post_detail_history: (data) => {
        const url = '/api/DetailHistory'
        return axiosClient.post(url, data)
    }

}

export default HistoryAPI