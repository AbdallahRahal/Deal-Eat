import React from 'react';
import { View, ActivityIndicator, SafeAreaView, Image, StyleSheet, TouchableOpacity, FlatList, ScrollViewBase } from 'react-native';
import { Text, List, ListItem } from 'native-base';
import { CustomHeader } from '../../CustomHeader';
import Colors from '../../../constants/Colors';
import Icon from 'react-native-vector-icons/Ionicons';
import StarRating from 'react-native-star-rating';
import { ScrollView } from 'react-native-gesture-handler';





export class RestaurantDetail extends React.Component {

  constructor(props) {
    //this.props.navigation.getParam(paramName, defaultValue)
    super(props)
    this.state = {
      isLoading: true,
      dataSource: [],
      feedbackSource: [],
      ReductionSource: [],
      id: this.props.navigation.getParam('itemId'),
      menuSelect: 1,
      menuHoraireOpen: false,

    }

  }

  componentDidMount() {
    //const { navigation } = this.props;
    fetch('http://localhost:5000/api/Restaurant/getrestaurant/' + this.state.id)
      .then((response) => response.json())
      .then((responseJson) => {
        this.setState({
          isLoading: false,
          dataSource: responseJson
        })
      });

    fetch('http://localhost:5000/api/restaurant/getfeedbackbyrestaurant/' + this.state.id)
      .then((response2) => response2.json())
      .then((responseJson2) => {
        this.setState({
          feedbackSource: responseJson2
        })
      });

    fetch('http://localhost:5000/api/reduction/GetReductionByRestaurant/' + this.state.id)
      .then((response3) => response3.json())
      .then((responseJson3) => {
        this.setState({
          ReductionSource: responseJson3
        })
      });
    /*fetch('http://localhost:5000/api/Restaurant/CreateNewFeedback/', {
      method: 'POST',
      headers: {
        Accept: 'application/json',
        'Content-Type': 'application/json',
      },
      body: JSON.stringify({
        Note: 2,
        Feedback: 'new feedback with json',
        CustomerId: 1,
        RestaurantId: 0
      }),
    });*/
  }


  render() {
    //console.log(JSON.stringify(navigation.getParam('itemId', 'NO-ID')))
    //console.log('json : ' + this.state.dataSource);

    if (this.state.isLoading) {
      return (
        <View style={{ flex: 1 }}>
          <CustomHeader title="Restaurant Detail" navigation={this.props.navigation} />
          <SafeAreaView style={{ flex: 1, backgroundColor: Colors.primaryGreen }} >

            <ActivityIndicator size='large' animating />

          </SafeAreaView>
        </View>
      );
    } else {

      return (
        <View style={{ flex: 1 }}>
          <CustomHeader title="Restaurant Detail" navigation={this.props.navigation} />
          <SafeAreaView style={{ flex: 1, backgroundColor: Colors.littleGrey }} >


            <View style={{ flex: 1, padding: 25 }}>
              <View style={{ paddingBottom: 15 }}>
                <Image
                  style={{ width: '100%', height: 170, alignSelf: 'center', borderRadius: 6 }}
                  source={{ uri: this.state.dataSource['photoLink'] }}
                />
              </View>

              {/* Nom du restaurant */}
              <View style={{ flex: 1 }}>



                <View style={{ paddingTop: 25, flexDirection: 'row', alignContent: 'center', justifyContent: 'space-between' }}>
                  <TouchableOpacity onPress={() => { this.setState({ menuSelect: 0 }) }}>
                    <Text style={(this.state.menuSelect == 0) ? styles.textMenuSelected : styles.textMenu}>
                      Réductions
                  </Text>
                  </TouchableOpacity>

                  <TouchableOpacity onPress={() => { this.setState({ menuSelect: 1 }) }}>
                    <Text style={(this.state.menuSelect == 1) ? styles.textMenuSelected : styles.textMenu}>
                      Informations
                  </Text>
                  </TouchableOpacity>

                  <TouchableOpacity onPress={() => { this.setState({ menuSelect: 2 }) }}>
                    <Text style={(this.state.menuSelect == 2) ? styles.textMenuSelected : styles.textMenu}>
                      Commentaires
                  </Text>
                  </TouchableOpacity>
                </View>
              </View>


              {(this.state.menuSelect == 0) ?
                <View style={{ flex: 5 }}>
                  {console.log(this.state.ReductionSource)}

                  <FlatList
                    data={this.state.ReductionSource}
                    contentContainerStyle={{
                      flexDirection: 'column',
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
                                  {item.name}
                                </Text>

                                <Text style={{ fontStyle: 'italic', margin: 5, textDecorationLine: 'underline' }}>Information : </Text>
                                <View style={{ flexDirection: 'row' }} >
                                  <Text >{item.information}</Text>
                                </View>

                                <View style={{  flex: 1, justifyContent: 'flex-end' }}>
                                  <View style={{ alignSelf: 'flex-end' }} >
                                    <View style={{flexDirection:'row'}}>
                                      <Text style={{}}> Prix : </Text>
                                      <Text style={{textDecorationLine:'line-through'}}>{item.price}€   </Text>
                                      <Text>{ item.price - item.reduction}€</Text>
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
                : null
              }


              {(this.state.menuSelect == 1) ?
                <View style={{ flex: 5, backgroundColor: 'white', borderRadius: 9 }}>

                  <View style={{}}>
                    <Text style={{ alignSelf: 'center', fontStyle: 'italic', fontSize: 26, fontWeight: 'bold', color: '#1C1C1C' }}>
                      {this.state.dataSource['name']}
                    </Text>
                  </View>

                  <View style={{ flexDirection: 'row', justifyContent: 'space-between', }}>

                    <View style={{ paddingHorizontal: 20, paddingTop: 18 }}>
                      <Text style={styles.subCategoriesFoods}>{this.state.dataSource['category']}</Text>
                      {console.log(this.state.dataSource)}
                    </View>

                    <View style={{ paddingHorizontal: 20, paddingTop: 10 }}>
                      <View style={{ flexDirection: 'column', paddingTop: 10, }}>
                        <StarRating
                          disabled={true}
                          maxStar={5}
                          starSize={15}
                          rating={3.7}
                        />
                        <Text style={styles.avis}>{3} avis</Text>
                      </View>
                    </View>

                  </View>


                  <View style={{}}>
                    <View style={{ flexDirection: 'row', marginHorizontal: 25, marginTop: 15 }}>
                      <Text style={{ fontWeight: 'bold', fontSize: 16, }}>Adresse :  </Text>
                      <Text>{this.state.dataSource['adresse']}</Text>
                    </View>

                    <View style={{ flexDirection: 'row', marginHorizontal: 25, marginTop: 15 }}>
                      <Text style={{ fontWeight: 'bold', fontSize: 16 }}>Téléphone :  </Text>
                      <Text>{this.state.dataSource['telephone']}</Text>
                    </View>

                    <View style={{ flexDirection: 'row', marginHorizontal: 25, marginTop: 15 }}>
                      <Text style={{ fontWeight: 'bold', fontSize: 16 }}>Horaires :  </Text>
                      <Text style={styles.open}>  Ouvert   </Text>
                      <TouchableOpacity onPress={() => { this.setState({ menuHoraireOpen: !this.state.menuHoraireOpen }) }} >
                        {(!this.state.menuHoraireOpen) ?
                          <Icon name='ios-arrow-dropdown-circle' color='black' size={26} />
                          :
                          <Icon name='ios-arrow-dropup' color='black' size={26} />
                        }
                      </TouchableOpacity>
                    </View>

                    {(this.state.menuHoraireOpen) ?
                      <View style={{ flexDirection: 'row', }}>

                        <View style={{ alignSelf: 'flex-end', }}>
                          <List style={{ flexDirection: 'column', alignItems: 'flex-end', }}>
                            <Text style={styles.days}>   Lundi : </Text>
                            <Text style={styles.days}>   Mardi : </Text>
                            <Text style={styles.days}>   Mercredi : </Text>
                            <Text style={styles.days}>   Jeudi : </Text>
                            <Text style={styles.days}>   Vendredi : </Text>
                            <Text style={styles.days}>   Samedi : </Text>
                            <Text style={styles.days}>   Dimanche : </Text>
                          </List>
                        </View>

                        <View style={{ marginLeft: 0, }}>
                          <List style={{ flexDirection: 'column', alignItems: 'flex-start' }}>
                            <Text style={styles.daysHours}>   7:30 - 20:00   </Text>
                            <Text style={styles.daysHours}>   7:30 - 20:00   </Text>
                            <Text style={styles.daysHours}>   7:30 - 20:00   </Text>
                            <Text style={styles.daysHours}>   7:30 - 20:00   </Text>
                            <Text style={styles.daysHours}>   7:30 - 20:00   </Text>
                            <Text style={styles.daysHours}>   7:30 - 20:00   </Text>
                            <Text style={styles.daysHours}>   Fermé </Text>
                          </List>
                        </View>

                      </View>
                      : null
                    }
                  </View>
                </View>
                : null
              }




              {(this.state.menuSelect == 2) ?

                <View style={{ flex: 5, }}>

                  <View style={{ flex: 4, margin: 20, }}>
                    {console.log(this.state.feedbackSource)}

                    <View >
                      <View  >
                        <FlatList
                          data={this.state.feedbackSource}

                          contentContainerStyle={{
                            flexDirection: 'column',
                            justifyContent: 'space-between',
                          }}

                          renderItem={({ item }) =>
                            <View >

                              <View style={{ flexDirection: 'row', }}>

                                <View style={{ flex: 2 }}>
                                  <Text style={{ fontWeight: 'bold', fontStyle: 'italic', }}>
                                    {item.name}
                                  </Text>
                                </View>

                                <View style={{
                                  flex: 1
                                  , justifyContent: 'flex-end', alignContent: 'flex-end', alignItems: 'flex-end', alignSelf: 'flex-end',
                                }}>
                                  <StarRating
                                    disabled={true}
                                    maxStar={5}
                                    starSize={15}
                                    rating={item.note}
                                  />
                                </View>

                              </View>


                              <View style={{
                                flex: 5, width: 300, minHeight: 50, backgroundColor: 'white', borderRadius: 9,
                                alignItems: 'center', marginHorizontal: 10, marginBottom: 20, justifyContent: 'center'
                              }}>
                                <Text style={{ alignSelf: 'flex-start', paddingLeft: 10 }}>
                                  {item.feedBack}
                                </Text>
                              </View>
                            </View>

                          }
                          keyExtractor={item => item.feedBack}
                        />
                      </View>
                    </View>

                  </View>

                  <View style={{
                    margin: 0, justifyContent: 'flex-end', borderWidth: 2, borderColor: 'blue',
                    backgroundColor: 'white', borderRadius: 3, marginHorizontal: 10, justifyContent: 'center', alignItems: 'center',
                  }}>
                    <Text
                      style={{ minHeight: 50 }}>Laisser votre avis ici ...</Text>
                  </View>
                </View>


                : null
              }



            </View>

          </SafeAreaView>
        </View>
      );
    }
  }
};

const styles = StyleSheet.create({
  textMenu: {
    fontSize: 14,
    fontWeight: 'normal',
    color: 'black',
    //borderColor: 'red',
    //borderWidth: 3,
    textAlign: 'center'
  },
  textMenuSelected: {
    textAlign: 'center',
    color: 'black',
    fontSize: 25,
    fontWeight: 'bold',
    textDecorationLine: 'underline',
    textDecorationColor: 'blue'
  },
  open: {
    color: 'green',
    fontSize: 18,
    fontWeight: 'bold'
  },
  avis: {
    paddingTop: 5,
    color: '#1E90FF',
    fontSize: 15,
    fontStyle: 'italic'
  },
  subCategoriesFoods: {
    marginTop: 3,
    paddingLeft: 5,
    color: Colors.subTitleRed,
    fontSize: 16,
    fontStyle: 'italic',
    //borderColor: 'red',
    //borderWidth: 2,
    paddingTop: 0
  },
  subName: {
    marginTop: 4,
    paddingLeft: 5,
    fontSize: 17,
    fontWeight: 'bold',
    flex: 0.7,
    //borderColor: 'blue',
    //borderWidth: 2,
    marginBottom: -20
  },
  days: {
    fontWeight: 'bold',
    fontSize: 16,
    marginLeft: 65,
    marginTop: 5
  },
  daysHours: {
    fontWeight: 'normal',
    fontSize: 15,

    marginTop: 6
  }
});