import { getAsync, postAsync, putAsync, deleteAsync } from '../helpers/apiHelper'

const endpoint = process.env.VUE_APP_BACKEND + "/api/restaurant";

export async function getRestaurantListAsync() {
    return await getAsync(endpoint);
}