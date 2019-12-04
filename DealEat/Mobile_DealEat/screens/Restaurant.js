import React, { Component } from 'react';
import {
    View,
    Text,
    StyleSheet,
    ScrollView,
    SafeAreaView
} from 'react-native';
import Colors from '../constants/Colors';

class Restaurant extends Component {
    render() {
        return (
            <SafeAreaView style={{ flex: 1, backgroundColor: Colors.primaryGreen }} >

                <View style={styles.header}>

                </View>
                <View style={styles.container} >


                    <ScrollView scrollEventThrottle={16} >
                        <Text>Page Restaurant</Text>
                    </ScrollView>
                </View>
            </SafeAreaView>

        );
    }
}



export default Restaurant;


const styles = StyleSheet.create({
    
    header: {
        height: 80,
        backgroundColor: Colors.primaryGreen,
        borderColor: Colors.littleGrey,
        borderBottomWidth: 1,
    },

    container: {
        flex: 1,
        backgroundColor: 'white',

    },

});
