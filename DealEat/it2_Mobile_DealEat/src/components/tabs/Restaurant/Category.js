import React, { Component } from 'react';
import {
    View,
    Text,
    StyleSheet,
    Image
} from 'react-native';
import Colors from '../../../constants/Colors';

class Category extends Component{
    render() {
        return(
            <View style={styles.recommendationContainer}>
            <View style={{ flex: 2 }}>
                <Image style={styles.recommendationImage} source={this.props.imgUrl} />
            </View>
            <View style={{ flex: 1 }}>
                <Text style={styles.recommendationNameRestaurant}>{this.props.name}</Text>
            </View>
        </View>

        );
    }
}

export default Category;


const styles= StyleSheet.create({

    recommendationContainer: {
        height: 130,
        width: 130,
        padding: 5,
        marginHorizontal : 5,
        borderWidth: 0.5,
        borderColor: Colors.littleGrey,
        backgroundColor: 'white'
    },

    recommendationImage: {
        flex: 1,
        height: null,
        width: null,
        resizeMode: 'cover',
    },

    recommendationNameRestaurant: {
        paddingTop: 10,
        paddingLeft: 5,
        textAlign: "left",

    },

});