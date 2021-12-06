import axios from 'axios';
export const URL = `https://localhost:44349/api/`;

export default axios.create({
    baseURL: URL
});