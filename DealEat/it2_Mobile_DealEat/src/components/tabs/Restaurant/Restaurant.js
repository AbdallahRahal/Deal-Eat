import React, { Component } from 'react';
import {
  View,
  StyleSheet,
  ScrollView,
  SafeAreaView,
  Dimensions,
  ActivityIndicator,
  FlatList,
  Image,
  TouchableOpacity
} from 'react-native';
import { Text, Button, Col, Item } from 'native-base';
import { CustomHeader } from '../../CustomHeader';
import Colors from '../../../constants/Colors';
import Category from './Category';
import RestaurantPreview from './RestaurantPreview';


export class Restaurant extends React.Component {

  constructor(props) {
    super(props)
    this.state = {
      isLoading: true,
      dataSource: []
    }
  }

  componentDidMount() {
    fetch('http://localhost:5000/api/Restaurant')
      .then((response) => response.json())
      .then((responseJson) => {
        this.setState({
          isLoading: false,
          dataSource: responseJson
        })
      })
  }


  render() {
    console.log(this.state.dataSource);
    return (

      <View style={{ flex: 1 }}>
        <CustomHeader title="Restaurant" isHome={true} navigation={this.props.navigation} />
        <SafeAreaView style={{ flex: 1, backgroundColor: Colors.primaryGreen }} >

          {
            this.state.isLoading ?
              <View>
                <ActivityIndicator size='large' animating />
              </View>

              : <ScrollView >
                <View style={styles.container} >
                  <Text style={styles.title}>Dans quels restaurants {'\n'}allez-vous manger aujourd'hui ?</Text>
                  <Text style={styles.subTitle} >Les recommandations de l'équipe :</Text>
                  {/*<Text> {(this.state.data == null) ? null : this.state.data[0]['name']} </Text> */}
                  <View style={{ height: 130, marginTop: 10, }}>
                    <ScrollView horizontal={true} showsHorizontalScrollIndicator={false} >
                      <Category name='Chez Marwan'
                        imgUrl={require('../../../images/Chez_Marwan.jpeg')}
                      />
                      <Category name='Thaï'
                        imgUrl={require('../../../images/Thai.jpg')}
                      />
                      <Category name='Paul'
                        imgUrl={require('../../../images/Paul.jpeg')}
                      />
                      <Category name='Chez Marwan'
                        imgUrl={require('../../../images/Chez_Marwan.jpeg')}
                      />
                    </ScrollView>
                  </View>


                  <View style={{ backgroundColor: Colors.littleGrey }}>
                    <View style={styles.line}></View>

                    <View>
                      <Text style={styles.title} >Les restaurants autour de vous</Text>
                    </View>

                    <View style={{ marginTop: 20 }}>
                      <View style={styles.containerRestaurantAround} >
                        <FlatList
                          data={this.state.dataSource}
                          contentContainerStyle={{
                            flexDirection: 'row',
                            flexWrap: "wrap",
                            justifyContent: 'space-between',
                          }}
                          renderItem={({ item }) =>
                            <TouchableOpacity
                              onPress={() => {
                                this.props.navigation.navigate('RestaurantDetail', {
                                  itemId: item.restaurantId,
                                })
                              }}
                            >
                              <RestaurantPreview
                                picture={item.photoLink}
                                categories={item.category}
                                nameRestaurant={item.name}
                                average={4.3}
                                nbNotes={143}
                                distance={0.4}
                              />
                            </TouchableOpacity>
                          }
                          keyExtractor={item => item.restaurantId}
                        />
                      </View>
                    </View>
                  </View>
                </View>
              </ScrollView>
          }
        </SafeAreaView>
      </View>


    );
  }
}




const styles = StyleSheet.create({

  header: {
    height: 80,
    backgroundColor: Colors.primaryGreen,
    borderColor: Colors.littleGrey,
    borderBottomWidth: 1,
  },

  container: {
    flex: 1,
    backgroundColor: Colors.littleGrey,
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
    borderWidth: 0.0,
    paddingHorizontal: 20,
    borderColor: Colors.littleGrey,
    flex: 1,
    flexDirection: 'row',
    flexWrap: "wrap",
    justifyContent: 'space-between',
    //backgroundColor: Colors.primaryGreen
    //backgroundColor: Colors.littleGrey
  },


});

{ /*<View style={{ flex: 1 }}>
<CustomHeader title="Restaurant" isHome={true} navigation={this.props.navigation} />
<View style={{ flex: 1, justifyContent: 'center', alignItems: 'center' }}>
  <Text>Restaurant Screen !</Text>
  <Button onPress={() => this.props.navigation.navigate('RestaurantDetail')} >
    <Text>Go to Restaurant Details</Text>
  </Button>
</View>
</View>
*/}