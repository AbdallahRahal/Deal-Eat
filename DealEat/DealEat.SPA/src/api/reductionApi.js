import { getAsync, postAsync, putAsync, deleteAsync } from '../helpers/apiHelper'


const endpoint = process.env.VUE_APP_BACKEND + "/api/reduction";


export async function getReductionListAsync() {
    return await getAsync(endpoint);
}

export async function getReductionByIdAsync(reductionId) {
    return await getAsync(`${endpoint}/${reductionId}`);
}
