// SPDX-License-Identifier: MIT
pragma solidity >=0.8.7 <0.9.0;
import "https://github.com/OpenZeppelin/openzeppelin-contracts/blob/master/contracts/token/ERC1155/ERC1155.sol";
import "https://github.com/OpenZeppelin/openzeppelin-contracts/blob/master/contracts/access/Ownable.sol";
import "https://github.com/OpenZeppelin/openzeppelin-contracts/blob/master/contracts/utils/Counters.sol";
import "./MintingToken.sol";

contract Inventory is ERC1155, Ownable {
    using Counters for Counters.Counter;
    Counters.Counter private _tokenIds;

    mapping(uint256 => uint256) private _tokenPrices;
    mapping(uint256 => uint256) private _tokenPricesEXE;

    address token;

    //constructor(address token_) ERC1155("https://api.covalenthq.com/v1/1/block_v2/5000000/application/json") {
       // constructor(address token_) ERC1155("https://polygon.w3node.com/811babf8e7d051e4187909f142e2ad8f42a1ac9d358bb3f7e2ee8fe051ae8664/api") {
        constructor(address token_) ERC1155("https://cronos.w3node.com/f79ad59086fdf41460a8d57e849ebe5334f6c62556f9eb17629fe9200c69f75f/api") {
        token = token_;
    }

    function updateToken(address token_) public onlyOwner {
        token = token_;
    }

    function mint(uint256 price, uint256 priceInSPT) public onlyOwner {
        require(msg.sender != address(0), "invalid address");
        require(price > 0, " invalid amount");
        _tokenIds.increment();
        _tokenPrices[_tokenIds.current()] = price;
        _tokenPricesEXE[_tokenIds.current()] = priceInSPT;
        _mint(msg.sender, _tokenIds.current(), 1, "");
    }

    function mint(uint256 token_id) public payable {
        require(msg.sender != address(0), "invalid address");
        require(token_id > 0, "invalid token");
        require(balanceOf(msg.sender, token_id) == 0, "already minted");
        if (_tokenPrices[token_id] == msg.value) {
            _mint(msg.sender, token_id, 1, "");
        } else {
            MintingToken(token).burnFrom(msg.sender, _tokenPricesEXE[token_id]);
            _mint(msg.sender, token_id, 1, "");
        }
    }
}