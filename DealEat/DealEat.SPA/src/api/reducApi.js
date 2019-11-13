import { getAsync, postAsync, putAsync, deleteAsync } from '../helpers/apiHelper'


const endpoint = process.env.VUE_APP_BACKEND + "/api/reduc";


export async function getReducListAsync() {
    return await getAsync(endpoint);
}

export async function getReducByIdAsync(restaurantId) {
    return await getAsync(`${endpoint}/${restaurantId}`);
}
