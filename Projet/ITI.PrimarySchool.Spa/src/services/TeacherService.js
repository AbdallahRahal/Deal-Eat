import { getBearer } from './AuthenticationService'

const serviceUrl = process.env.VUE_APP_API_URL + '/api/teacher';

export const getById = async teacherId => {
  let response = await fetch(serviceUrl + '/' + teacherId);
  return await response.json();
}

export const getAll = async () => {
  let response = await fetch(serviceUrl);
  return await response.json();
}

export const deleteTeacher = async teacherId => {
  let jwt = getBearer();
  await fetch(serviceUrl + '/' + teacherId, {
    method: 'DELETE',
    headers: {
      'Authorization': 'Bearer ' + jwt
    }
  });
}