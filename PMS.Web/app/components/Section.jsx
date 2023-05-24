import {Text, useColorScheme, View} from 'react-native';

import {Colors} from 'react-native/Libraries/NewAppScreen';

import Styles from './common/Styles';

const Section = ({children, title}) => {
  const isDarkMode = useColorScheme() === 'dark';
  
	return (
    <View style={Styles.sectionContainer}>
      <Text
        style={[
          Styles.sectionTitle,
          {
            color: isDarkMode ? Colors.white : Colors.black,
          },
        ]}>
        {title}
      </Text>
      <Text
        style={[
          Styles.sectionDescription,
          {
            color: isDarkMode ? Colors.light : Colors.dark,
          },
        ]}>
        {children}
      </Text>
    </View>
  );
};

export default Section;
