import React, {Component} from 'react';
import {View, Text, StyleSheet } from 'react-native';

class Search extends Component {
    render() {
        return(
            <View style={styles.container} >
                <Text>Page Search</Text>
            </View>
        );
    }
}



export default Search;


const styles = StyleSheet.create({
    container: {
      flex: 1,
      backgroundColor: '#13a34c',
      alignItems: 'center',
      justifyContent: 'center',
    },
  });
  