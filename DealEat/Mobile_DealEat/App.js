import React from 'react';
import { StyleSheet, Text, View, Image } from 'react-native';

import { createBottomTabNavigator } from 'react-navigation';
import Colors from './constants/Colors';

// Navigation by the bottom_tab_bar
import SearchScreen from './screens/SearchScreen';
import UserScreen from './screens/UserScreen';
import ReductionScreen from './screens/ReductionScreen';
import RestaurantScreen from './screens/RestaurantScreen';

// Icons - For bottom_tab_bar
import Icon from 'react-native-vector-icons/Ionicons';
import Icon2 from 'react-native-vector-icons/Feather';




export default createBottomTabNavigator({
  Search: {
    screen: SearchScreen,
    navigationOptions: {
      tabBarLabel: 'RECHERCHE',
      tabBarIcon: ({ tintColor }) => (
        <Icon name="ios-search" color={tintColor} size={25} />
      )
    }
  },


  Reduction: {
    screen: ReductionScreen,
    navigationOptions: {
      tabBarLabel: 'RÉDUCTIONS',
      tabBarIcon: ({ tintColor }) => (
        <Icon name="ios-barcode" color={tintColor} size={25} />
      )
    }
  },

  Restaurant: {
    screen: RestaurantScreen,
    navigationOptions: {
      tabBarLabel: 'RESTAURANTS',
      tabBarIcon: ({ tintColor }) => (
        <Image source={require('./assets/restaurantsLogo.png')}
          style={{ height: 25, width: 25, tintColor: tintColor }}
        />
      )
    }
  },

  Favorites: {
    screen: UserScreen,
    navigationOptions: {
      tabBarLabel: 'USER',
      tabBarIcon: ({ tintColor }) => (
        <Icon2 name="user" color={tintColor} size={25} />
      )
    }
  }

},
{
  // BottomTabNavigatorConfig :
  // -The routeName for the initial tab route when first loading.
  initialRouteName: 'Reduction',

  // -Style
  tabBarOptions: {
    activeTintColor: 'red',
    inactiveTintColor: 'white',
    style: {
      backgroundColor: Colors.primaryGreen,
      borderTopWidth: 0,
      shadowOffSet: { width: 6, height: 4 },
      shadowColor: 'black',
      shadowOpacity: 0.6,
      elevation: 5
    }
  },

}

)

const styles = StyleSheet.create({
  container: {
    flex: 1,
    backgroundColor: Colors.primaryGreen,
    alignItems: 'center',
    justifyContent: 'center',
  },
});
