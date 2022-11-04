// SPDX-License-Identifier: MIT
pragma solidity ^0.8.7;

import "https://github.com/smartcontractkit/chainlink/blob/develop/contracts/src/v0.8/interfaces/LinkTokenInterface.sol";
import "https://www.google.com/search?client=firefox-b-d&q=VRFCoordinatorV2Interface.sol+github";
import "https://github.com/smartcontractkit/chainlink/blob/develop/contracts/src/v0.8/VRFConsumerBaseV2.sol";



contract RandomLegends is VRFConsumerBaseV2 {
    uint256 private constant ROLL_IN_PROGRESS = 5;

    VRFCoordinatorV2Interface COORDINATOR;    
    LinkTokenInterface LINKTOKEN;

    // Your subscription ID.
    uint64 s_subscriptionId;
    address link_token_contract = 0x326C977E6efc84E512bB9C30f76E30c160eD06FB;
    address vrfCoordinator = 0x7a1BaC17Ccc5b313516C5E16fb24f7659aA5ebed;
    bytes32 s_keyHash = 0x4b09e658ed251bcafeebbc69400383d49f344ace09b9576fe248bb02c003fe9f;


    uint32 callbackGasLimit = 25000;

    // The default is 3, but you can set this higher.
    uint16 requestConfirmations = 3;

    // For this example, retrieve 1 random value in one request.
    // Cannot exceed VRFCoordinatorV2.MAX_NUM_WORDS.
    uint32 numWords = 1;
    address s_owner;

    // map rollers to requestIds
    mapping(uint256 => address) public s_rollers;
    // map vrf results to rollers
    mapping(address => uint256) public s_results;
    uint256 public ss_results;

 

    event DiceRolled(uint256 indexed requestId, address indexed roller);
    event DiceLanded(uint256 indexed requestId, uint256 indexed result);

    event RandomNumber(uint256 d5Value);

    // let contract_abi = abi_json _code_during_contract_compilation;
    // let EventTest = web3.eth.contract(contract_abi);
    // let EventTestContract = ClientReceipt.at("0x98...");

    // EventTestContract.transfer(function(err, data) {
    //   if (!err)
    //   console.log(data);
    // });


    // mapping(bytes32=>uint256) public randomMap;
    // mapping(address=>bytes32) public requestMap;

    uint256 public d5Value;
 
    constructor(uint64 subscriptionId) VRFConsumerBaseV2(vrfCoordinator) { //uint64 subscriptionId
        COORDINATOR = VRFCoordinatorV2Interface(vrfCoordinator);
        LINKTOKEN = LinkTokenInterface(link_token_contract);
        s_owner = msg.sender;
        //Create a new subscription when you deploy the contract.
        //createNewSubscription();
        s_subscriptionId = subscriptionId;

        
    }


      function rollDice() public onlyOwner returns (uint256 requestId) {
        //require(s_results[roller] == 0, 'Already rolled');
        // Will revert if subscription is not set and funded.
        requestId = COORDINATOR.requestRandomWords(
            s_keyHash,
            s_subscriptionId,
            requestConfirmations,
            callbackGasLimit,
            numWords
        );

        s_rollers[requestId] = s_owner;
        ss_results = s_results[s_owner] = ROLL_IN_PROGRESS;
        emit DiceRolled(requestId, s_owner);
    }

    //function voidNull() 
    function callNumberResult() public view returns(uint256){
      
        return d5Value;
    }
  

    function fulfillRandomWords(uint256 requestId, uint256[] memory randomWords) internal override {
        d5Value = (randomWords[0] % 5) + 1;
        s_results[s_rollers[requestId]] = d5Value;
        emit DiceLanded(requestId, d5Value);
    }


    function house(address player) public view returns (string memory) {
        require(s_results[player] != 0, 'Dice not rolled');
        require(s_results[player] != ROLL_IN_PROGRESS, 'Roll in progress');
        return getHouseName(s_results[player]);
    }


    function getHouseName(uint256 id) private pure returns (string memory) {
        string[5] memory houseNames = [
            'Fire',
            'Earth',
            'Metal',
            'Water',
            'Wood'
        ];
        return houseNames[id - 1];
    }

  

  // Create a new subscription when the contract is initially deployed.
  function createNewSubscription() private onlyOwner {
    s_subscriptionId = COORDINATOR.createSubscription();
    // Add this contract as a consumer of its own subscription.
    COORDINATOR.addConsumer(s_subscriptionId, address(this));
  }

  // Assumes this contract owns link.
  // 1000000000000000000 = 1 LINK
  function topUpSubscription(uint256 amount) external onlyOwner {
    LINKTOKEN.transferAndCall(address(COORDINATOR), amount, abi.encode(s_subscriptionId));
  }

  function addConsumer(address consumerAddress) external onlyOwner {
    // Add a consumer contract to the subscription.
    COORDINATOR.addConsumer(s_subscriptionId, consumerAddress);
  }

  function removeConsumer(address consumerAddress) external onlyOwner {
    // Remove a consumer contract from the subscription.
    COORDINATOR.removeConsumer(s_subscriptionId, consumerAddress);
  }

  function cancelSubscription(address receivingWallet) external onlyOwner {
    // Cancel the subscription and send the remaining LINK to a wallet address.
    COORDINATOR.cancelSubscription(s_subscriptionId, receivingWallet);
    s_subscriptionId = 0;
  }

  // Transfer this contract's funds to an address.
  // 1000000000000000000 = 1 LINK
  function withdraw(uint256 amount, address to) external onlyOwner {
    LINKTOKEN.transfer(to, amount);
  }

  modifier onlyOwner() {
    require(msg.sender == s_owner);
    _;
  }

}
