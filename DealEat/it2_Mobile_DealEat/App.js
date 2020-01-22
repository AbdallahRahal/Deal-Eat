import React from 'react';
import { StyleSheet, Image, Dimensions } from 'react-native';
import { createAppContainer, createSwitchNavigator } from 'react-navigation';
import { createBottomTabNavigator } from 'react-navigation-tabs';
import { createStackNavigator } from 'react-navigation-stack';

import { IMAGE } from './src/constants/Images';
import { createDrawerNavigator } from 'react-navigation-drawer';

import Icon from 'react-native-vector-icons/Ionicons';
import Icon2 from 'react-native-vector-icons/Feather';

import {
  Login, Register, Profile, Setting, Reduction, ReductionDetail, Restaurant, RestaurantDetail,
  SideMenu, Favoris
} from './src/components';


const navOptionHandler = (navigation) => ({
  headerShown: false
})

const ReductionStack = createStackNavigator({
  Reduction: {
    screen: Reduction,
    navigationOptions: navOptionHandler
  },
  ReductionDetail: {
    screen: ReductionDetail,
    navigationOptions: navOptionHandler
  }
});

const RestaurantStack = createStackNavigator({
  Restaurant: {
    screen: Restaurant,
    navigationOptions: navOptionHandler
  },
  RestaurantDetail: {
    screen: RestaurantDetail,
    navigationOptions: navOptionHandler
  }
});

const MainTabs = createBottomTabNavigator({
  Restaurant: {
    screen: RestaurantStack,
    navigationOptions: {
      tabBarLabel: 'RESTAURANTS',
      tabBarIcon: ({ tintColor }) => (
        <Image source={require('./src/images/restaurantsLogo.png')}
        style={{ height: 25, width: 25, tintColor: tintColor }}
      />
        /*<Image
          source={IMAGE.ICON_USER_DEFAULT}
          resizeMode="contain"
          style={{ width: 20, height: 20 }}
        />*/
      )
    }
  },
  Reduction: {
    screen: ReductionStack,
    navigationOptions: {
      tabBarLabel: 'RÉDUCTIONS',
      tabBarIcon: ({ tintColor }) => (
        <Icon name="ios-barcode" color={tintColor} size={25} />
      )
    }
  }
});

const MainStack = createStackNavigator({
  Home: {
    screen: MainTabs,
    navigationOptions: navOptionHandler,
  },
  Setting: {
    screen: Setting,
    navigationOptions: navOptionHandler,
  },
  Profile: {
    screen: Profile,
    navigationOptions: navOptionHandler,
  },
  Favoris: {
    screen: Favoris,
    navigationOptions: navOptionHandler,
  },
}, { initialRouteName: 'Home' });

const appDrawer = createDrawerNavigator(
  {
    drawer: MainStack
  },
  {
    contentComponent: SideMenu,
    drawerWidth: Dimensions.get('window').width * 3 / 4
  }
);

const authStack = createStackNavigator({
  Login: {
    screen: Login,
    navigationOptions: navOptionHandler
  },
  Register: {
    screen: Register,
    navigationOptions: navOptionHandler
  }
})

const MainApp = createSwitchNavigator(
  {
    app: appDrawer,
    auth: authStack
  },
  { initialRouteName: 'app' }
);





export default createAppContainer(MainApp);

const styles = StyleSheet.create({
  container: {
    flex: 1,
    backgroundColor: '#fff',
    alignItems: 'center',
    justifyContent: 'center',
  },
});
