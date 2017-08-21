#include <stdlib.h>
//Definition for singly-linked list.
struct ListNode {
    int val;
    struct ListNode *next;
};

struct ListNode* removeNthFromEnd(struct ListNode* head, int n) {
    struct ListNode* fastTracker = head;
    struct ListNode* slowTracker = head;
    for(int i = n; i>0;--i){
        fastTracker = fastTracker->next;
    }
    if(fastTracker == NULL){
        return head->next;
    }
    while(fastTracker->next != NULL){
        fastTracker = fastTracker->next;
        slowTracker = slowTracker->next;
    }
    slowTracker->next = (slowTracker->next)->next;
    return head;
}
