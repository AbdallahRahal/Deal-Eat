import { getAsync, postAsync, putAsync, deleteAsync } from '../helpers/apiHelper'


const endpoint = process.env.VUE_APP_BACKEND + "/api/restaurant";


export async function getRestaurantListAsync() {
    return await getAsync(endpoint);
}

export async function getRestaurantByIdAsync(restaurantId) {
    return await getAsync(`${endpoint}/${restaurantId}`);
}
<<<<<<< HEAD
/*
=======

>>>>>>> 07a7e1c6e3dbc2deeb73407c8db13e9aef678bbb
export async function createRestaurantAsync(model) {
    return await postAsync(endpoint, model);
}

<<<<<<< HEAD
export async function deleteRestaurantAsync(restaurantId) {
=======
/*export async function deleteRestaurantAsync(restaurantId) {
>>>>>>> 07a7e1c6e3dbc2deeb73407c8db13e9aef678bbb
    return await deleteAsync(`${endpoint}/${restaurantId}`);
}*/
