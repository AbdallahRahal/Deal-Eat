import React, { Component } from 'react';
import {
    View,
    Text,
    StyleSheet,
    Dimensions,
    Image

} from 'react-native';
import Icon from 'react-native-vector-icons/Ionicons';
import Icon2 from 'react-native-vector-icons/Entypo';
import Colors from '../../constants/Colors';
import StarRating from 'react-native-star-rating';

const { height, width } = Dimensions.get('window');

class RestaurantPreview extends Component {
    render() {
        return (
            <View style={styles.containerRestaurant}>

                <View style={{ flex: 1 }}>
                    <Image source={require('../../assets/Chez_Marwan.jpeg')}
                        style={{ flex: 1, height: null, width: null, resizeMode: 'cover' }} />
                </View>

                <View style={styles.containerRestaurantText}>
                    <View>
                        <Text style={styles.subCategoriesFoods}>Pizza - Burger - Fastfood</Text>
                        <Text style={styles.subName} >Chez Marwan</Text>
                    </View>

                    <View style={{ flex: 1, flexDirection: 'row', paddingHorizontal: 5, width: (width / 2) - 30 }}>
                        <View style={{ flexDirection: 'column', alignSelf: 'flex-end'}}>
                            <StarRating
                                disabled={true}
                                maxStar={5}
                                starSize={15}
                                rating={4.4}
                            />
                            <Text style={styles.avis}>143 avis</Text>
                        </View>


                        <View style={{ flex: 1 }}>
                        </View>

                        <View style={{ flexDirection: 'column', alignSelf: 'flex-end' }}>
                            <View style={{}}>
                                <Text style={styles.open}>Ouvert</Text>
                            </View>

                            <View style={{ flexDirection: 'row' }}>
                                <Icon name='ios-walk' color='black' size={16} />
                                <Icon2 name='dot-single' color='black' size={16} />
                                <Text style={styles.subDistanceGPS} >0.4 km</Text>
                            </View>
                        </View>
                    </View>
                </View>

            </View>

        );
    }
}


export default RestaurantPreview;

const styles = StyleSheet.create({

    containerRestaurant: {
        width: (width / 2) - 30,
        height: (width / 2) - 30,
        borderColor: Colors.littleGrey,
        borderWidth: 0.5,
        marginBottom: 20,
    },

    containerRestaurantText: {
        flex: 1,
        alignItems: 'flex-start',
    },

    subCategoriesFoods: {
        marginTop: 3,
        paddingLeft: 5,
        color: Colors.subTitleRed,
        fontSize: 12,
        fontStyle: 'italic',
    },

    subName: {
        marginTop: 4,
        paddingLeft: 5,
        fontSize: 17,
        fontWeight: 'bold',
        flex: 0.7,
    },

    avis: {
        color: '#1E90FF',
        fontSize: 13,
        fontStyle:'italic'
    },

    subDistanceGPS: {
        fontSize: 14,
        fontWeight: '500',
        color: 'grey',
    },
    open: {
        color: 'green',
        fontSize: 16,
        paddingLeft: 5,
        paddingTop: 2,
        alignSelf: 'flex-end',
        fontWeight: 'bold'
    }
}); 