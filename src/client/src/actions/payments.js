import * as action from "./types";
import axios from "axios";
import { fetchTransactions } from "./transactions";

const ROOT_URL = "/api";
/**
 * Проводит withdraw транзакцию
 *
 * @param {String} from
 * @param {String} to
 * @param {Integer} sum
 * @returns
 */
export const TransferMoney = (from, to, sum) => {
  return async dispatch => {
    try {
      // set payment started action
      dispatch({
        type: action.PAYMENT_STARTED
      });

      // send post request to transfer money
      const response = await axios.post(`${ROOT_URL}/transactions`, {sum, from, to});

      // print result
      console.log(response.data);
      
      // fetch and display transactions
      dispatch(fetchTransactions(response.data.from));

    } catch (error) {
      // print error
      console.log(error);
      
      // set payment failed
      dispatch({
        type: action.PAYMENT_FAILED,
        payload: err.response
      });      
    }
  }
};

export const repeateTransferMoney = () => dispatch =>
  dispatch({
    type: action.PAYMENT_REPEAT
  });
