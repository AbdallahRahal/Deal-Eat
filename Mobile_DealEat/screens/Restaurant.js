import React, {Component} from 'react';
import {View, Text, StyleSheet } from 'react-native';

class Restaurant extends Component {
    render() {
        return(
            <View style={styles.container} >
                <Text>Page Restaurant</Text>
            </View>
        );
    }
}



export default Restaurant;


const styles = StyleSheet.create({
    container: {
      flex: 1,
      backgroundColor: '#13a34c',
      alignItems: 'center',
      justifyContent: 'center',
    },
  });
  