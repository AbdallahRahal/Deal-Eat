import React from 'react';
import { View, Image, SafeAreaView, ScrollView } from 'react-native';
import { Text, List, ListItem } from 'native-base';
import { IMAGE } from '../constants/Images';
import Icon2 from 'react-native-vector-icons/Feather';



export class SideMenu extends React.Component {
    render() {
        return (
            <SafeAreaView style={{ flex: 1 }} >
                <View style={{ height: 150, alignItems: 'center', justifyContent: 'center' }} >
                    <Image source={IMAGE.ICON_USER_DEFAULT}
                        style={{ height: 120, width: 120, borderRadius: 60 }} />
                </View>

                <ScrollView>
                    <List>
                        <ListItem onPress={() => this.props.navigation.navigate('Profile')} >
                            <Icon2 name="user" size={25} />
                            <Text>   Profile</Text>
                        </ListItem>

                        <ListItem onPress={() => this.props.navigation.navigate('Favoris')} >
                            <Icon2 name="heart" size={25} />
                            <Text>   Favoris</Text>
                        </ListItem>

                        <ListItem onPress={() => this.props.navigation.navigate('Setting')} >
                            <Icon2 name="settings" size={25} />
                            <Text>   Setting</Text>
                        </ListItem>
                    </List>
                </ScrollView>

                <List>
                    <ListItem noBorder onPress={() => this.props.navigation.navigate('auth')}>
                        <Icon2 name="log-out" size={25} />
                        <Text>   Déconnexion</Text>
                    </ListItem>
                </List>
            </SafeAreaView>
        )
    }
}