import React from 'react';
import PropTypes from 'prop-types';
import { Link } from 'react-router-dom';

Products.propTypes = {
    products: PropTypes.array,
    sort: PropTypes.string,
    GET_id_modal: PropTypes.func
};

Products.defaultProps = {
    products: [],
    sort: '',
    GET_id_modal: null
}

function Products(props) {

    const { products, sort, GET_id_modal } = props

    if (sort === 'DownToUp') {
        products.sort((a, b) => {
            return a.price_product - b.price_product
        });
    }
    else if (sort === 'UpToDown') {
        products.sort((a, b) => {
            return b.price_product - a.price_product
        });
    }

    return (
        <div className="row">
            {
                products && products.map(value => (
                    <div className="col-lg-4 col-sm-6 animate__animated animate__zoomIn col_product" key={value.id_product}>
                        <div className="single-product-wrap">
                            <div className="product-image">
                                <Link to={`/detail/${value.id_product}`}>
                                    {
                                        value.image.substring(0, 5) === 'https' ?
                                            (
                                                <img src={value.image} alt="Li's Product Image" />
                                            ) :
                                            (
                                                <img src={"data:image/png;base64," + value.image} alt="Li's Product Image" />
                                            )
                                    }
                                </Link>
                                <span className="sticker">New</span>
                            </div>
                            <div className="product_desc">
                                <div className="product_desc_info">
                                    <div className="product-review">
                                        <h5 className="manufacturer">
                                            <a href="shop-left-sidebar.html">{value.name_product}</a>
                                        </h5>
                                        <div className="rating-box">
                                            <ul className="rating">
                                                <li><i className="fa fa-star-o"></i></li>
                                                <li><i className="fa fa-star-o"></i></li>
                                                <li><i className="fa fa-star-o"></i></li>
                                                <li className="no-star"><i className="fa fa-star-o"></i></li>
                                                <li className="no-star"><i className="fa fa-star-o"></i></li>
                                            </ul>
                                        </div>
                                    </div>
                                    <div className="price-box">
                                        <span className="new-price">${value.price_product}</span>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                ))
            }
        </div>
    );
}

export default Products;