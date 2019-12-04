import React, { Component } from 'react';
import {
    View,
    Text,
    StyleSheet,
    ScrollView,
    SafeAreaView,
    Image
} from 'react-native';
import Colors from '../constants/Colors';
import Category from '../components/Restaurant/Category';

class RestaurantScreen extends Component {
    render() {
        return (
            <SafeAreaView style={{ flex: 1, backgroundColor: Colors.primaryGreen }} >

                <View style={styles.header}>
                </View>

                <View style={styles.container} >
                    <Text style={styles.title}>Dans quels restaurants {'\n'}allez-vous manger aujourd'hui ?</Text>
                    <Text style={styles.subTitle} >Les recommandations de l'équipe :</Text>

                    <View style={{ height: 130, marginTop: 10, }}>
                        <ScrollView horizontal={true} showsHorizontalScrollIndicator={false} >

                            <Category name='Chez Marwan'
                                imgUrl={require('../assets/Chez_Marwan.jpeg')}
                            />
                            <Category name='Thaï'
                                imgUrl={require('../assets/Thai.jpg')}
                            />
                            <Category name='Paul'
                                imgUrl={require('../assets/Paul.jpeg')}
                            />
                            <Category name='Chez Marwan'
                                imgUrl={require('../assets/Chez_Marwan.jpeg')}
                            />


                        </ScrollView>
                    </View>

                </View>
            </SafeAreaView>
        );
    }
}



export default RestaurantScreen;


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

    title: {
        fontSize: 24,
        fontWeight: '700',
        margin: 10,
        paddingHorizontal: 5,
        textAlign: "center",
    },

    subTitle: {
        fontSize: 15,
        color: 'black',
        fontStyle: 'italic',
        marginTop: 10
    },

});
