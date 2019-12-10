import React, { Component } from "react";
import {
  View,
  Text,
  StyleSheet,
  SafeAreaView,
  TextInput,
  Platform,
  StatusBar
} from "react-native";
import Icon from "react-native-vector-icons/Ionicons";

class SearchScreen extends Component {
  render() {
    return (
      <SafeAreaView style={{ flex: 1, backgroundColor:"#13a34c" }}>
        <View style={styles.container}>

          <View style={styles.containerSearchBar}>         
            <View style={styles.searchBar}>
              <Icon name="ios-search" size={21} style={{ marginRight: 10 }} />
              <TextInput
                underlineColorAndroid="transparent"
                placeholder="Rechercher un restaurant / réduction"
                placeholderTextColor="grey"
                style={styles.inputSearchBar}
              />
            </View>
          </View>

          <Text>Page Search</Text>

        </View>

      </SafeAreaView>
    );
  }
}

export default SearchScreen;

const styles = StyleSheet.create({
  container: {
    flex: 1,
    //backgroundColor: "#13a34c",
    backgroundColor: "white"
  },

  containerSearchBar: {
    height: 80,
    backgroundColor: "#13a34c",
    borderColor: "grey",
    borderBottomWidth: 1
  },

  searchBar: {
    flexDirection: "row",
    marginTop: 15,
    marginHorizontal: 20,
    backgroundColor: "white",
    padding: 10,
    alignContent: "center",
    justifyContent: "center",
    shadowColor: "black",
    shadowOpacity: 0.2,
    shadowOffset: { width: 0, height: 0 },
    elevation: 1
  },

  inputSearchBar: {
    fontWeight: "700",
  },


});
