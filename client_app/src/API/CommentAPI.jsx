import axiosClient from './axiosClient'

const CommentAPI = {

    get_comment: (id) => {
        const url = `/api/Comment/${id}`
        return axiosClient.get(url)
    },

    post_comment: (query) => {
        const url = `/api/Comment${query}`
        return axiosClient.post(url)
    }

}

export default CommentAPI