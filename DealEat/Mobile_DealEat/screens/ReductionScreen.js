import React, { Component, useState } from 'react';
import { View, Text, StyleSheet, SafeAreaView } from 'react-native';
import Colors from '../constants/Colors';

//class ReductionScreen extends Component {
const ReductionScreen = props => {

    const [data, setData] = useState();

     

    //render() {
        return (
            <SafeAreaView style={{ flex: 1, backgroundColor: Colors.primaryGreen }} >

                <View style={styles.container} >
                    <Text>Page Reduction</Text>
                </View>
                
            </SafeAreaView>
        );
    //}
}



export default ReductionScreen;


const styles = StyleSheet.create({
    container: {
        flex: 1,
        backgroundColor: 'white',
        alignItems: 'center',
        justifyContent: 'center',
    },
});
