module Bowling {
    angular.module("bowlingApp")
        .filter("displayDelivery", [displayDelivery]);

    function displayDelivery() {
        return function (rollRecords: IRollRecord[], frameIndex: number, deliveryIndex: number): string {
            switch (deliveryIndex) {
                case 0:
                    if (rollRecords[frameIndex].delivery1 == null) {
                        return "";
                    }

                    return rollRecords[frameIndex].delivery1 == 10 ? "X" : rollRecords[frameIndex].delivery1.toString();
                case 1:
                    if (rollRecords[frameIndex].delivery2 == null) {
                        return "";
                    }

                    if (frameIndex == 10) {
                        return rollRecords[frameIndex].delivery2 == 10 ? "X" : (rollRecords[frameIndex].delivery1 + rollRecords[frameIndex].delivery2) == 10 ? "/" : rollRecords[frameIndex].delivery2.toString();
                    }

                    return (rollRecords[frameIndex].delivery1 + rollRecords[frameIndex].delivery2) == 10 ? "/" : rollRecords[frameIndex].delivery2.toString();
                case 2:
                    if (rollRecords[frameIndex].delivery3 == null) {
                        return "";
                    }

                    if (frameIndex == 10) {
                        return rollRecords[frameIndex].delivery3 == 10 ? "X" : rollRecords[frameIndex].delivery3.toString();
                    }

                    return "";
                default:
                    return "";
            }
        };
    }
} 