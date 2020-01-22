import { getAsync, postAsync, putAsync, deleteAsync } from '../helpers/apiHelper'


const endpoint = process.env.VUE_APP_BACKEND + "/api/restaurant";


export async function getRestaurantListAsync() {
    return await getAsync(endpoint);
}

export async function getRestaurantByIdAsync(restaurantId) {
    return await getAsync(`${endpoint}/GetRestaurant/${restaurantId}`);
}


export async function getRestaurantByIdWebAsync(restaurantId) {
    return await getAsync(`${endpoint}/GetRestaurantWeb/${restaurantId}`);
}

export async function UpdateRestaurantAsync(restaurantId,model) {
    return await postAsync(`${endpoint}/UpdateRestaurant/${restaurantId}`,model);
}

/*
export async function createRestaurantAsync(model) {
    return await postAsync(endpoint, model);
}

/*export async function deleteRestaurantAsync(restaurantId) {
    return await deleteAsync(`${endpoint}/${restaurantId}`);
}*/
