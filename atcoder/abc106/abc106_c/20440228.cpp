// detail: https://atcoder.jp/contests/abc106/submissions/20440228
#include<bits/stdc++.h>
using ll = long long;
#define var auto
const char newl = '\n';

using namespace std;

template<typename T1, typename T2> inline void chmin(T1& a, T2 b) { if (a > b) a = b; }
template<typename T1, typename T2> inline void chmax(T1& a, T2 b) { if (a < b) a = b; }

int main() {
  string s;
  cin >> s;
  int k;
  cin >> k;
  for (var&& c : s) {
    k--;
    if (k == 0) {
      cout << c << endl;
      return 0;
    }
    if (c == '1') continue;
    cout << c << endl;
    return 0;
  }
}
