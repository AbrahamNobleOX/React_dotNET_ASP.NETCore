import axios, { AxiosError, AxiosResponse } from "axios";

// set the base url for the api
axios.defaults.baseURL = "http://localhost:3001/api/";

// get the response body
const responseBody = (response: AxiosResponse) => response.data;

// intercept the response and log the error to the console
axios.interceptors.response.use(
  (response) => {
    return response;
  },
  (error: AxiosError) => {
    console.log("caught by interceptor");
    return Promise.reject(error.response);
  }
);

// define the requests object with the get, post, put, and delete methods
const requests = {
  get: (url: string) => axios.get(url).then(responseBody), // get the url and return the response body
  post: (url: string, body: {}) => axios.post(url, body).then(responseBody), // post the url and body and return the response body
  put: (url: string, body: {}) => axios.put(url, body).then(responseBody), // put the url and body and return the response body
  delete: (url: string) => axios.delete(url).then(responseBody), // delete the url and return the response body
};

// define the Catalog object with the list and details methods
const Catalog = {
  list: () => requests.get("products"), // get the list of products
  details: (id: number) => requests.get(`products/${id}`), // get the product details
};

// define the TestErrors object with methods
const TestErrors = {
  get400Error: () => requests.get("buggy/bad-request"),
  get401Error: () => requests.get("buggy/unauthorised"),
  get404Error: () => requests.get("buggy/not-found"),
  get500Error: () => requests.get("buggy/server-error"),
  getValidationError: () => requests.get("buggy/validation-error"),
};

const agent = {
  Catalog,
  TestErrors,
};

export default agent;
