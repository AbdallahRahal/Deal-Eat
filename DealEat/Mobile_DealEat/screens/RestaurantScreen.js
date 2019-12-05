import React, { Component } from 'react';
import {
    View,
    Text,
    StyleSheet,
    ScrollView,
    SafeAreaView,
    Dimensions
} from 'react-native';
import Colors from '../constants/Colors';
import Category from '../components/Restaurant/Category';

import RestaurantPreview from '../components/Restaurant/RestaurantPreview';


const { height, width } = Dimensions.get('window');

class RestaurantScreen extends Component {

    render() {
        return (
            <SafeAreaView style={{ flex: 1, backgroundColor: Colors.primaryGreen }} >

                <View style={styles.header}>
                </View>
                <ScrollView >

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

                        <View style={styles.line}></View>

                        <View>
                            <Text style={styles.title} >Les restaurants autour de vous</Text>
                        </View>

                        <View style={{ marginTop: 20 }}>
                            <View style={styles.containerRestaurantAround} >

                                <RestaurantPreview
                                    picture={require('../assets/Chez_Marwan.jpeg')}
                                    categories='Burger - Pizza - FastFood'
                                    nameRestaurant='Chez Marwan'
                                    average={4.3}
                                    nbNotes={143}
                                    distance={0.4}
                                />
                                <RestaurantPreview
                                    picture={require('../assets/Thai.jpg')}
                                    categories='Thai - FastFood'
                                    nameRestaurant='Thaï'
                                    average={2.7}
                                    nbNotes={58}
                                    distance={2.8}
                                />
                                <RestaurantPreview
                                    picture={require('../assets/Paul.jpeg')}
                                    categories='Boulangerie - Sandwich'
                                    nameRestaurant='Chez Paul'
                                    average={4.8}
                                    nbNotes={243}
                                    distance={0.8}
                                />
                                <RestaurantPreview
                                    picture={require('../assets/Chez_Marwan.jpeg')}
                                    categories='Burger - Pizza - FastFood'
                                    nameRestaurant='Chez Marwan'
                                    average={4.3}
                                    nbNotes={143}
                                    distance={0.4}
                                />
                                <RestaurantPreview
                                    picture={require('../assets/Thai.jpg')}
                                    categories='Thai - FastFood'
                                    nameRestaurant='Thaï'
                                    average={2.7}
                                    nbNotes={58}
                                    distance={2.8}
                                />
                            </View>
                        </View>

                    </View>
                </ScrollView>

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
        paddingHorizontal: 5,
        fontSize: 24,
        fontWeight: '700',
        textAlign: "center",
    },

    subTitle: {
        marginTop: 30,
        marginLeft: 10,
        fontSize: 15,
        color: 'black',
        fontStyle: 'italic',
    },

    line: {
        marginTop: 20,
        marginBottom: 30,
        marginHorizontal: 30,
        borderBottomColor: 'black',
        borderBottomWidth: 1,
    },
    containerRestaurantAround: {
        borderWidth: 0.5,
        paddingHorizontal: 20,
        borderColor: Colors.littleGrey,
        flex: 1,
        flexDirection: 'row',
        flexWrap: "wrap",
        justifyContent: 'space-between'
    },

});
