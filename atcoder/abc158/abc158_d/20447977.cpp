// detail: https://atcoder.jp/contests/abc158/submissions/20447977
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
  string front = "";
  int q;
  cin >> q;
  bool flipped = false;
  for (int i = 0; i < q; i++) {
    int t;
    cin >> t;
    if (t == 1) {
      flipped ^= true;
    }
    else {
      int f; char c;
      cin >> f >> c;
      if ((f == 1) ^ flipped) front += c;
      else s += c;
    }
  }
  reverse(front.begin(), front.end());
  s = front + s;
  if (flipped) {
    reverse(s.begin(), s.end());
  }
  cout << s << endl;
}
