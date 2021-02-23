// detail: https://atcoder.jp/contests/sumitrust2019/submissions/20438864
#include<bits/stdc++.h>
using ll = long long;
#define var auto
const char newl = '\n';

using namespace std;

template<typename T1, typename T2> inline void chmin(T1& a, T2 b) { if (a > b) a = b; }
template<typename T1, typename T2> inline void chmax(T1& a, T2 b) { if (a < b) a = b; }

const int MAX = 100001;

bool possible[MAX] = { true };

int main() {
  
  int x;
  cin >> x;
  vector<int> prods{ 100, 101, 102, 103, 104, 105 };
  for (var&& p : prods) {
    for (int i = 0; i + p < MAX; i++) {
      possible[i + p] |= possible[i];
    }
  }
  cout << (possible[x] ? 1 : 0) << endl;
}
