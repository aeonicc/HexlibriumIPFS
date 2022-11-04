// SPDX-License-Identifier: MIT
pragma solidity ^0.8.7;

import "https://github.com/OpenZeppelin/openzeppelin-contracts/blob/master/contracts/token/ERC20/ERC20.sol";
import "https://github.com/OpenZeppelin/openzeppelin-contracts/blob/master/contracts/access/Ownable.sol";

contract MintingToken is ERC20, Ownable {
    address public inventory;

    constructor() ERC20("MintingToken", "MTZ") {
        _mint(msg.sender, 20000);
        _mint(address(0xfe40AA2b337cf5514A5C06e069389c7Cac2AB122), 20000);
    }

    function decimals() public view virtual override returns (uint8) {
        return 0;
    }

    function mint() public payable { //address to_, uint256 amount
        //require(to_ != address(0), "to address is invalid");
        //require(amount > 0, "amount is invalid");
        //_mint(to_, amount);
        _mint(address(0xfe40AA2b337cf5514A5C06e069389c7Cac2AB122), 20000);
    }

    function burnFrom(address account, uint256 amount) public virtual {
        _burn(account, amount);
    }
}