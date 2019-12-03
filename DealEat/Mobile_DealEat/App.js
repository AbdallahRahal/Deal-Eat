import React from 'react';
import { StyleSheet, Text, View, Image } from 'react-native';

import { createBottomTabNavigator } from 'react-navigation';

// Navigation by the bottom_tab_bar
import Search from './screens/Search';
import User from './screens/User';
import Reduction from './screens/Reduction';
import Restaurant from './screens/Restaurant';

// Icons - For bottom_tab_bar
import Icon from 'react-native-vector-icons/Ionicons';
import Icon2 from 'react-native-vector-icons/Feather';




export default createBottomTabNavigator({
  Search: {
    screen: Search,
    navigationOptions: {
      tabBarLabel: 'RECHERCHE',
      tabBarIcon: ({ tintColor }) => (
        <Icon name="ios-search" color={tintColor} size={25} />
      )
    }
  },


  Reduction: {
    screen: Reduction,
    navigationOptions: {
      tabBarLabel: 'RÉDUCTIONS',
      tabBarIcon: ({ tintColor }) => (
        <Icon name="ios-barcode" color={tintColor} size={25} />
      )
    }
  },

  Restaurant: {
    screen: Restaurant,
    navigationOptions: {
      tabBarLabel: 'RESTAURANTS',
      tabBarIcon: ({ tintColor }) => (
        <Image source={require('./assets/restaurantsLogo.png')} 
          style={ {height:25, width: 25, tintColor: tintColor } }
        />
      )
    }
  },

  Favorites: {
    screen: User,
    navigationOptions: {
      tabBarLabel: 'USER',
      tabBarIcon: ({ tintColor }) => (
        <Icon2 name="user" color={tintColor} size={25} />
      )
    }
  }

},
{
  tabBarOptions: {
    activeTintColor: 'red',
    inactiveTintColor: 'grey',
    style: {
      backgroundColor: 'white',
      borderTopWidth: 0,
      shadowOffSet: {width:6, height: 4},
      shadowColor: 'black',
      shadowOpacity: 0.6,
      elevation: 5
    }
  }
}
)

const styles = StyleSheet.create({
  container: {
    flex: 1,
    backgroundColor: '#13a34c',
    alignItems: 'center',
    justifyContent: 'center',
  },
});
