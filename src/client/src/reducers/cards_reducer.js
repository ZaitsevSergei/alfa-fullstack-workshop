import * as actions from "../actions/types";

/**
 * Возвращает массив с обновленным элементом
 *
 * @param {Array} array
 * @param {Object} action
 * @returns {Array}
 */
const addOrUpdateObjectInArray = (array, newItem, field = "number") => {
  let isNew = true;
  const newArray = array.map(item => {
    if (item[field] !== newItem[field]) return item;
    isNew = false;
    return newItem;
  });
  if (isNew) newArray.push(newItem);
  return newArray;
};

const initialState = {
  data: [],
  error: null,
  isLoading: false,
  activeCardNumber: null
};

export default (state = initialState, { type, payload }) => {
  switch (type) {
    case actions.CARDS_FETCH_STARTED:
      return {
        ...state,
        isLoading: state.data.length === 0 ? true : false
      };

    case actions.CARD_FETCH_SUCCESS:
    return {
      ...state,
      data: addOrUpdateObjectInArray(state.data, payload)
    };

    case actions.CARDS_FETCH_FAILED:
      return {
        ...state,
        error: payload,
        isLoading: false
      };

    case actions.ACTIVE_CARD_CHANGED:
      return {
        ...state,
        activeCardNumber: payload
      };   

      case actions.CARD_ADD_STARTED:
      return {
          ...state,
          isLoading: state.data.length === 0 ? true : false
      };

    case actions.CARD_ADD_SUCCESS:
      return {
        ...state,
        data: addOrUpdateObjectInArray(state.data, payload),
        error: null,
        isLoading: false
      };

    case actions.CARD_ADD_FAILED:
      return {
        ...state,
        isLoading: false
      };
  

    default:
      return state;
  }
};
