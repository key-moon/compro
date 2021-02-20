#include<bits/stdc++.h>

using ll = long long;
#define var auto

using namespace std;

template<typename T1, typename T2> inline void chmin(T1& a, T2 b) { if (a > b) a = b; }
template<typename T1, typename T2> inline void chmax(T1& a, T2 b) { if (a < b) a = b; }

int main() {
  int n;
  cin >> n;
  vector<bool> states(n);
  for (int i = 0; i < n; i++) {
    string state;
    cin >> state;
    states[i] = state == "T";
  }
  stack<bool> st{};
  string buf;
  cin.ignore();
  getline(cin, buf);
  for (int i = 0; i < buf.size(); i += 2) {
    char c = buf[i];
    if ('A' <= c && c <= 'Z') {
      st.push(states[c - 'A']);
      continue;
    }
    if (c == '*') {
      var t1 = st.top(); st.pop();
      var t2 = st.top(); st.pop();
      st.push(t1 & t2);
      continue;
    }
    if (c == '+') {
      var t1 = st.top(); st.pop();
      var t2 = st.top(); st.pop();
      st.push(t1 | t2);
      continue;
    }
    if (c == '-') {
      var t1 = st.top(); st.pop();
      st.push(!t1);
    }
  }
  cout << (st.top() ? "T" : "F") << endl;
}
