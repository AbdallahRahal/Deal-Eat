import React, {Component} from 'react';
import {View, Text, StyleSheet } from 'react-native';

class ReductionScreen extends Component {
    render() {
        return(
            <View style={styles.container} >
                <Text>Page Reduction</Text>
            </View>
        );
    }
}



export default ReductionScreen;


const styles = StyleSheet.create({
    container: {
      flex: 1,
      backgroundColor: '#13a34c',
      alignItems: 'center',
      justifyContent: 'center',
    },
  });
  