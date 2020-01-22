import React from 'react';
import { View } from 'react-native';
import { Text, Button} from 'native-base';
import {CustomHeader} from '../../CustomHeader';

export class Reduction extends React.Component {
    render() {
      return (
        <View style={{ flex: 1 }}>
          <CustomHeader title="Réduction" isHome={true} navigation={this.props.navigation} />
          <View style={{ flex: 1, justifyContent: 'center', alignItems: 'center' }}>
            <Text>Réduction Screen !</Text>
            <Button onPress={() => this.props.navigation.navigate('ReductionDetail')} >
              <Text>Go to Réduction Details</Text>
            </Button>
          </View>
        </View>
      );
    }
  }