import axiosClient from './axiosClient'

const CommentAPI = {

    get_comment: (id) => {
        const url = `/api/Comment/${id}`
        return axiosClient.get(url)
    },

    post_comment: (data) => {
        const url = `/api/Comment`
        return axiosClient.post(url, data)
    }

}

export default CommentAPI