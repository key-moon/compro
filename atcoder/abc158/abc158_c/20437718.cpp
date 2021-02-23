// detail: https://atcoder.jp/contests/abc158/submissions/20437718
#include<bits/stdc++.h>
using ll = long long;
#define var auto
const char newl = '\n';

using namespace std;

template<typename T1, typename T2> inline void chmin(T1& a, T2 b) { if (a > b) a = b; }
template<typename T1, typename T2> inline void chmax(T1& a, T2 b) { if (a < b) a = b; }

int main() {
  int a, b;
  cin >> a >> b;
  for (int i = 0; i < 100000; i++) {
    var A = i * 8 / 100;
    var B = i * 10 / 100;
    if (a == A && b == B) {
      cout << i << endl;
      return 0;
    }
  }
  cout << -1 << endl;
}
