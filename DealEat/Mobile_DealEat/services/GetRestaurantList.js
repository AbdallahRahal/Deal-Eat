import React, { Component } from 'react';
import { View, Text, StyleSheet } from 'react-native';

const urlApi = 'http://localhost:5000/api/Restaurant';



async function GetRestaurantListFromApi() {
    let reponse = await fetch(urlApi);
    let responseJson = await reponse.json();
    return responseJson;
}




export default GetRestaurantListFromApi;

const styles = StyleSheet.create({

});


/*return fetch(urlApi)
    .then((response) => response.json())
    .then((responseJson) => {
        this.setState.data : responseJson,
            this.setState.isLoading = false
    })
    .catch((error) => {
        console.log(error)
    });*/

     /*setTimeout(() => {
                this.state.data = GetRestaurantList();
                console.log(this.state);
                //console.log(this.state.data[0]['name']);
            }, 2000);*/

            