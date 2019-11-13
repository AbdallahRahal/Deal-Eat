import { getAsync, postAsync, putAsync, deleteAsync } from '../helpers/apiHelper'


const endpoint = process.env.VUE_APP_BACKEND + "/api/restaurant";


export async function getRestaurantListAsync() {
    return await getAsync(endpoint);
}

export async function getRestaurantByIdAsync(restaurantId) {
    return await getAsync(`${endpoint}/${restaurantId}`);
}

export async function createRestaurantAsync(model) {
    return await postAsync(endpoint, model);
}

/*export async function deleteRestaurantAsync(restaurantId) {
    return await deleteAsync(`${endpoint}/${restaurantId}`);
}*/
