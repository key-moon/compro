// detail: https://atcoder.jp/contests/abc071/submissions/20436337
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
  unordered_set<char> st{};
  for (var&& c : s) st.insert(c);
  for (char c = 'a'; c <= 'z'; c++) {
    if (st.count(c)) continue;
    cout << c << endl;
    return 0;
  }
  cout << "None" << endl;
}
