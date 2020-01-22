import React from 'react';
import { View, ActivityIndicator, SafeAreaView, Image, StyleSheet, TouchableOpacity, FlatList, ScrollViewBase } from 'react-native';
import { Text, List, ListItem, Button } from 'native-base';
import { CustomHeader } from '../../CustomHeader';
import Colors from '../../../constants/Colors';
import Icon from 'react-native-vector-icons/Ionicons';
import StarRating from 'react-native-star-rating';
import { ScrollView } from 'react-native-gesture-handler';


export class Reduction extends React.Component {

  constructor(props) {
    //this.props.navigation.getParam(paramName, defaultValue)
    super(props)
    this.state = {
      isLoading: true,
      ReductionSource: [],
      //id: this.props.navigation.getParam('itemId'),
    }
  }

  componentDidMount() {
    //const { navigation } = this.props;
    fetch('http://localhost:5000/api/Reduction')
      .then((response) => response.json())
      .then((responseJson) => {
        this.setState({
          isLoading: false,
          ReductionSource: responseJson
        })
      });
  }



  render() {


    if (this.state.isLoading) {
      return (
        <View style={{ flex: 1 }}>
          <CustomHeader title="RéductionDetail" navigation={this.props.navigation} />
          <SafeAreaView style={{ flex: 1, backgroundColor: Colors.primaryGreen }} >

            <ActivityIndicator size='large' animating />

          </SafeAreaView>
        </View>
      );
    } else {
      { console.log(this.state.ReductionSource) }

      return (

        <View style={{ flex: 1 }}>
          <CustomHeader title="Restaurant Detail" navigation={this.props.navigation} />
          <SafeAreaView style={{ flex: 1, backgroundColor: Colors.littleGrey }} >



            <View style={{ flex: 5 , paddingTop:15}}>
              {console.log(this.state.ReductionSource)}

              <FlatList
                data={this.state.ReductionSource}
                contentContainerStyle={{
                  flexDirection: 'column'
                  , 
                }}
                renderItem={({ item }) =>

                
                  <View>
                    <View style={{
                      borderColor: 'green', borderWidth: 3
                      , width: 350, minHeight: 150, backgroundColor: 'white', borderRadius: 9,
                      marginHorizontal: 10, marginBottom: 20,
                    }}>

                      <View style={{ flexDirection: 'row' }}>

                        <View style={{ flex: 1 }}>
                          <Image
                            style={{
                              width: '100%', height: 150, alignSelf: 'flex-start', borderRadius: 6, resizeMode: 'cover',
                            }}
                            source={{ uri: item.photoLink }}
                          />
                        </View>


                        <View style={{ flex: 2, width: 200, }}>
                          <View style={{ flex: 1, flexDirection: 'column', padding: 5 }}>

                            <Text style={{ fontSize: 21, fontWeight: 'bold', alignSelf: 'center' }}>
                              {item.bracketName}
                            </Text>

                            <Text style={{ fontStyle: 'italic', margin: 5, textDecorationLine: 'underline' }}>Information : </Text>
                            <View style={{ flexDirection: 'row' }} >
                              <Text >{item.information}</Text>
                            </View>

                            <View style={{ flex: 1, justifyContent: 'flex-end' }}>
                              <View style={{ alignSelf: 'flex-end' }} >
                                <View style={{ flexDirection: 'row' }}>
                                  <Text style={{}}> Prix : </Text>
                                  <Text style={{ textDecorationLine: 'line-through' }}>{item.price}€   </Text>
                                  <Text>{item.price - item.reduction}€</Text>
                                </View>
                              </View>
                            </View>
                          </View>
                        </View>

                      </View>
                    </View>
                  </View>
                }
                keyExtractor={item => (item.photoLink + item.name)}
              />



            </View>
          </SafeAreaView>
        </View>

      );
    }
  }
}